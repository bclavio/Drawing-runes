using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PathTracer : MonoBehaviour {

	public GameObject scoreObject, timeObject,scoreBox;//testing
    public static bool isEnabled = false;
    public static Text guiScore, guiTime;
	public static Image guiScoreBox; 
	public static GameObject path1, path2, path3, path4, path5, path6, catObj1, catObj2, catObj3, catObj4, catObj5, catObj1alphaObj;

    private float preX = -1;
    private float preY = -1;
    private RaycastHit hit;
    private List<Vector2> points;
    public static float nearestP;
	public static int currentLevel = 0;
    public bool withinRange;
    public long timestamp;

    private int changeTex;
    public static int width;
	
	void Start() {
        guiScore = scoreObject.GetComponent<Text>();
        guiTime = timeObject.GetComponent<Text>();
		guiScoreBox = scoreBox.GetComponent<Image>();
		
		path1 = GameObject.Find ("path1");
		path2 = GameObject.Find ("path2");
		path3 = GameObject.Find ("path3");
		path4 = GameObject.Find ("path4");
		path5 = GameObject.Find ("path5");		
		path6 = GameObject.Find ("ExitButton");
		
		catObj1 = GameObject.Find ("cat1");
		catObj2 = GameObject.Find ("cat2");
		catObj3 = GameObject.Find ("cat3");
		catObj4 = GameObject.Find ("cat4");
		catObj5 = GameObject.Find ("cat5");

        catObj1alphaObj = GameObject.Find("cat-transparent");

        guiScoreBox.enabled = false;

		path1.SetActive(false);
		path2.SetActive(false);
		path3.SetActive(false);
		path4.SetActive(false);
		path5.SetActive(false);	
		path6.SetActive(false);

		catObj1.SetActive(false);
		catObj2.SetActive(false);
		catObj3.SetActive(false);
		catObj4.SetActive(false);
		catObj5.SetActive(false);

        catObj1alphaObj.SetActive(false);
        withinRange = true;
    }

    void Update() {

        if (!isEnabled)
            return;
        
        if (Input.GetMouseButton(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Send a ray to collide with the plane

            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) { // change
                Vector2 uv;
                uv.x = (hit.point.x - hit.collider.bounds.min.x) / hit.collider.bounds.size.x;
                uv.y = (hit.point.y - hit.collider.bounds.min.y) / hit.collider.bounds.size.y;
                Texture2D tex = (Texture2D)hit.transform.gameObject.GetComponent<Renderer>().sharedMaterial.mainTexture;
                float x = uv.x * tex.width;
                float y = uv.y * tex.height;

                if (preX >= 0 && (preX != x || preY != y)) { 
					width = 30 ;
                    nearestP = width;

                    for (int i = -width / 2; i <= width / 2; i++)
                        for (int j = -width / 2; j <= width / 2; j++)
                        {
                            float pDistance = Mathf.Sqrt(Mathf.Pow(i, 2) + Mathf.Pow(j, 2));
                            if (pDistance <= width / 2.0)
                            {
                                Color pColor = tex.GetPixel((int)(x + i), (int)(y + j));
                                if (pColor != Color.black)
                                {
                                    if (pColor != Color.red)
                                        tex.SetPixel((int)(x + i), (int)(y + j), Color.red);
                                    if (nearestP > pDistance)
                                        nearestP = pDistance;
                                }
                            }
                        }
                    if (nearestP <= width / 2.0 && !withinRange || nearestP > width / 2.0 && withinRange)
                    {
                        withinRange = !withinRange;
                        if (withinRange)
                            Handler.appendTimeOffPath(Handler.getMillis() - timestamp);
                        else
                            timestamp = Handler.getMillis();
                    }

                    // time, distance, class, x, y
                    float elapsedTime = Handler.getElapsedTime();
                    if (Handler.getElapsedTime() > 0)
                        Logging.log(Handler.getElapsedTime() + "\t" + (nearestP <= width/2.0 ? nearestP + "\t" + 0 : GradiantLamp.getDistance() + "\t" + 1) + "\t" + x + "\t" + y);
                    //Debug.Log(GradiantLamp.getDistance());

                    nearestP /= width/2;

                    float length = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(preX - x), 2) + Mathf.Pow(Mathf.Abs(preY - y), 2));
                    Vector2 A, B;
                    A.x = preX;
                    A.y = preY;
                    B.x = x;
                    B.y = y;
                    float angle = Vector3.Angle(A, B);
                }
                preX = x;
                preY = y;
                //tex.Apply();
            }
        }
        else if (!Input.GetMouseButton(0) && preX >= 0) {
            preX = -1;
        }

    }

	public void setCurrentLevel(int level){
		currentLevel = level;
	}

    public static void displayScore() {
        guiTime.enabled = true;
        guiScore.enabled = true;
		guiScoreBox.enabled = true;
		Debug.Log ("Level : " + currentLevel);
		if (currentLevel == 0)
			path1.SetActive (true);
		else if(currentLevel == 1)
			path2.SetActive(true);
		else if(currentLevel == 2)
			path3.SetActive(true);
		else if(currentLevel == 3)
			path4.SetActive(true);
		else if(currentLevel == 4)
			path5.SetActive(true);
		else if(currentLevel == 5)
			path6.SetActive(true);


		//Dispay cat heads
		if (Handler.getAccuracy () >= 0) {
            catObj1alphaObj.SetActive(true);
            if (Handler.getAccuracy() >= 1) {
                catObj1.SetActive(true);
                if (Handler.getAccuracy() >= 25) {
                    catObj2.SetActive(true);
                    if (Handler.getAccuracy() >= 50) {
                        catObj3.SetActive(true);
                        if (Handler.getAccuracy() >= 75) {
                            catObj4.SetActive(true);
                            if (Handler.getAccuracy() >= 90) {
                                catObj5.SetActive(true);
                            }
                        }
                    }
                }
            }
		}

		//Debug.Log ("score");
        guiScore.text = "You hit " + (int)Handler.getAccuracy() + "% of the rune, but spend " + (Handler.timeDisplay).ToString("F2") + " seconds outside the line.";

        toggle(false);
		currentLevel ++;
    }  

    //arrayToCurve is original Vector3 array, smoothness is the number of interpolations. 
    public static Vector2[] MakeSmoothCurve(Vector2[] arrayToCurve, float smoothness) {
        List<Vector2> points;
        List<Vector2> curvedPoints;
        int pointsLength = 0;
        int curvedLength = 0;

        if (smoothness < 1.0f) smoothness = 1.0f;

        pointsLength = arrayToCurve.Length;
        curvedLength = (pointsLength * Mathf.RoundToInt(smoothness)) - 1;
        curvedPoints = new List<Vector2>(curvedLength);
        float t = 0.0f;

        for (int pointInTimeOnCurve = 0; pointInTimeOnCurve < curvedLength + 1; pointInTimeOnCurve++) {
            t = Mathf.InverseLerp(0, curvedLength, pointInTimeOnCurve);
            points = new List<Vector2>(arrayToCurve);
            
            for (int j = pointsLength - 1; j > 0; j--) {
                for (int i = 0; i < j; i++) {
                    points[i] = (1 - t) * points[i] + t * points[i + 1];
                }
            }
            curvedPoints.Add(points[0]);
        }
        return (curvedPoints.ToArray());
    }

    public static void toggle(bool b) {
        isEnabled = b;
    }

    public static int countPixels(Color target_color) { // slow function creates a delay! Easy solution DONE: calls function when mouse moves out of each inner circle (see Handler.cs). 
        int matches = 0;

        for (int y = 0; y < NewLevel.clone.height; y++){ 
            for (int x = 0; x < NewLevel.clone.width; x++){
                if (NewLevel.clone.GetPixel(x, y) == target_color) matches++;
            }
        }
        return matches;
    }
}
