using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class mouseTut : MonoBehaviour {

    public Color colorStart, colorEnd;
    public GameObject mouse, distanceUnitL, distanceUnitR;
    public static bool skammekrog;
	public float moveSpeed = 1.0f;
    private Renderer rend;
	private float unitDistance, lerb1;

	void Start() {
		rend = GetComponentInChildren<Renderer>();
	}
	
	void Update () {
		//Debug.Log (CylFollowAni.tutorialState);
		rend.enabled = false;
		Color alphaColor = rend.material.color;

		if (CylFollowAni.tutorialState == 0 ||CylFollowAni.tutorialState == 1 ||CylFollowAni.tutorialState == 2||CylFollowAni.tutorialState == 3||CylFollowAni.tutorialState == 5) {
			alphaColor.a = 0.0f;//set alpha to 0
		}
		else if (CylFollowAni.tutorialState == 4) {
            if (CylFollowAni.left == 1) unitDistance = Vector3.Distance(mouse.transform.position, distanceUnitL.transform.position);
            else if (CylFollowAni.left == 0) unitDistance = Vector3.Distance(mouse.transform.position, distanceUnitR.transform.position);
			lerb1 = unitDistance-5.0f;
			rend.material.color = Color.Lerp(colorStart, colorEnd, lerb1);
            rend.enabled = true;
        }
	}
}
