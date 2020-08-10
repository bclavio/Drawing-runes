using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewLevel : MonoBehaviour {
	public Texture2D[] myTextures = new Texture2D[1];
    public static Texture2D CurrentTex;
    private static Renderer rend;
    public static Texture2D clone;

	public static GameObject fadePlane1, fadePlane2, fadePlane3, fadePlane4, fadePlane5, cubeobjTut, cubeobjPath1, cubeobjPath2, cubeobjPath3, cubeobjPath4, cubeobjPath5, popUp, popupPaper;
	public static Image imageFadePlane1, imageFadePlane2, imageFadePlane3, imageFadePlane4, imageFadePlane5;

    void Start (){
        popupPaper = GameObject.Find("popUpPaper"); // new
        popupPaper.SetActive(false); // new

        rend = GetComponent<Renderer>();
		fadePlane1 = GameObject.Find ("ImagePlaneFade1");
		fadePlane2 = GameObject.Find ("ImagePlaneFade2");
		fadePlane3 = GameObject.Find ("ImagePlaneFade3");
		fadePlane4 = GameObject.Find ("ImagePlaneFade4");
		fadePlane5 = GameObject.Find ("ImagePlaneFade5");

        popUp = GameObject.Find("PopUpText");
        popUp.SetActive(false);

        cubeobjTut = GameObject.Find("cubeTut");
        cubeobjPath1 = GameObject.Find("cubepath1");
        cubeobjPath2 = GameObject.Find("cubepath2");
        cubeobjPath3 = GameObject.Find("cubepath3");
        cubeobjPath4 = GameObject.Find("cubepath4");
        cubeobjPath5 = GameObject.Find("cubepath5");

        if (CylFollowAni.left == 1) { // a quick fix for a null reference error, I couldnt figure out.
            cubeobjPath1.SetActive(false);
            cubeobjPath2.SetActive(false);
            cubeobjPath3.SetActive(false);
            cubeobjPath4.SetActive(false);
            cubeobjPath5.SetActive(false);
        }

        imageFadePlane1 = fadePlane1.GetComponent<Image>();
		imageFadePlane2 = fadePlane2.GetComponent<Image>();
		imageFadePlane3 = fadePlane3.GetComponent<Image>();
		imageFadePlane4 = fadePlane4.GetComponent<Image>();	
		imageFadePlane5 = fadePlane5.GetComponent<Image>();


		imageFadePlane1.enabled = false;
		imageFadePlane2.enabled = false;
		imageFadePlane3.enabled = false;
		imageFadePlane4.enabled = false;		
		imageFadePlane5.enabled = false;
    }
	
	
	public void ChangeToTutorialScene(int sceneToChangeTo){
		CurrentTex = myTextures[sceneToChangeTo]; 
		rend.material.mainTexture = CurrentTex; 
		clone = Instantiate(CurrentTex);
		GetComponent<Renderer>().material.mainTexture = clone;
		PathTracer.toggle(false);
		Handler.reset();
		//PathTracer.guiTime.enabled = false; 
		PathTracer.guiScore.enabled = false; 
	}

    public void ChangeToScene(int sceneToChangeTo){

        //PathTracer.guiTime.enabled = false;
        PathTracer.guiScore.enabled = false;
		PathTracer.guiScoreBox.enabled = false;
		ChangePath.infoPanel.enabled = false;
        ChangePath.infoText.enabled = false;
        ChangePath.infoTextlvl1.enabled = false;

        PathTracer.path1.SetActive (false);
		PathTracer.path2.SetActive (false);
		PathTracer.path3.SetActive (false);
		PathTracer.path4.SetActive (false);
		PathTracer.path5.SetActive (false);		
		PathTracer.path6.SetActive (false);

		PathTracer.catObj1.SetActive (false);
		PathTracer.catObj2.SetActive (false);
		PathTracer.catObj3.SetActive (false);
		PathTracer.catObj4.SetActive (false);
		PathTracer.catObj5.SetActive (false);
        PathTracer.catObj1alphaObj.SetActive(false);

        ChangePath.infoImage1.SetActive (false);
        ChangePath.infoImage2.SetActive (false);
        ChangePath.infoImage3.SetActive (false);
        ChangePath.infoImage4.SetActive (false);
        ChangePath.infoImage5.SetActive (false);

		imageFadePlane1.enabled = false;
		imageFadePlane2.enabled = false;
		imageFadePlane3.enabled = false;
		imageFadePlane4.enabled = false;		
		imageFadePlane5.enabled = false;
	
        if (sceneToChangeTo == 0) {
            popUp.SetActive(true);
            GradiantLamp.skammekrog = false;
        }

        else if (sceneToChangeTo == 1) {
			imageFadePlane1.enabled = true;
			imageFadePlane1.CrossFadeAlpha (0.0f, 2.0f, true);
            cubeobjTut.SetActive(false);
            cubeobjPath1.SetActive(true);
        }
        else if (sceneToChangeTo == 2) {
			imageFadePlane2.enabled = true;
			imageFadePlane2.CrossFadeAlpha (0.0f, 2.0f, true);
            cubeobjPath1.SetActive(false);
            cubeobjPath2.SetActive(true);
        }
        else if (sceneToChangeTo == 3) {
			imageFadePlane3.enabled = true;
			imageFadePlane3.CrossFadeAlpha (0.0f, 2.0f, true);
            cubeobjPath2.SetActive(false);
            cubeobjPath3.SetActive(true);
        }
        else if (sceneToChangeTo == 4) {
			imageFadePlane4.enabled = true;
			imageFadePlane4.CrossFadeAlpha (0.0f, 2.0f, true);
            cubeobjPath3.SetActive(false);
            cubeobjPath4.SetActive(true);

        }
        else if (sceneToChangeTo == 5) {
			imageFadePlane5.enabled = true;
			imageFadePlane5.CrossFadeAlpha (0.0f, 2.0f, true);
            cubeobjPath4.SetActive(false);
            cubeobjPath5.SetActive(true);
        }
        Debug.Log("Preparing new level..");
		CurrentTex = myTextures[sceneToChangeTo];
	
        rend.material.mainTexture = CurrentTex; 

        clone = Instantiate(CurrentTex);
        GetComponent<Renderer>().material.mainTexture = clone;
        PathTracer.toggle(false);
        Handler.reset();
	//	myFadeTextures[sceneToChangeTo].enabled = true;
	//	myFadeTextures[sceneToChangeTo].CrossFadeAlpha(0.0f, 2.0f, true);
    }

    public void Exit() {
        Debug.Log("quit game");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}