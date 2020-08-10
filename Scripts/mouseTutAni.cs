using UnityEngine;
using System.Collections;

public class mouseTutAni : MonoBehaviour {

    public Color colorStart, colorEnd;
    public GameObject mouse, distanceUnit;
    private float unitDistance;
    private float lerb1;
    private Renderer rend;

    void Start() {
        rend = GetComponentInChildren<Renderer>();
    }

    void Update () {
        if (CylFollowAni.tutorialState == 4 || CylFollowAni.tutorialState == 5) {
            unitDistance = Vector3.Distance(mouse.transform.position, distanceUnit.transform.position);
            //Debug.Log(unitDistance);
            if (unitDistance < 3) {
                rend.material.color = colorStart;
                Debug.Log("1: "+rend.material.color);
            }
            else if (unitDistance < 5) {
                lerb1 = unitDistance-4.0f;
                rend.material.color = Color.Lerp(colorStart, colorEnd, lerb1);
                //Debug.Log("2: " + rend.material.color);

            }
            else if (unitDistance >= 5) {
                rend.material.color = colorEnd;
                //Debug.Log("3: " + rend.material.color);

            }
        }
    }
}
