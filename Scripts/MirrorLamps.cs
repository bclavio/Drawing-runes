using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MirrorLamps : MonoBehaviour {
	public GameObject lamp;
	public Color colorStart, colorMiddle, colorMiddle2, colorEnd;
	private Renderer rend;
	public static bool isOn = false;


	void Start () {
		rend = GetComponentInChildren<Renderer>();
		lamp = GameObject.Find ("CylinderLamp");
	}
	
	// Update is called once per frame
	void Update () {
		rend.enabled = false;
		
		
		if (isOn==true && PathTracer.nearestP < 1) {

			rend.enabled = true;
			rend.material.color = Color.Lerp (colorStart, colorMiddle, PathTracer.nearestP);
		} 
		else if (isOn==true && PathTracer.nearestP >= 1) {
			rend.enabled = true;
			//Debug.Log (GradiantLamp.newLerb);
			rend.material.color = Color.Lerp (colorMiddle2, colorEnd,GradiantLamp.mirrorLerb);

		}
	}
	public void toggleOffset(){
		if (isOn == false) {
			isOn = true;
			
		} 
		else
			isOn = false;
	}
	
	public void moveLampToLeft(){
		lamp.transform.Translate(-14f, 0, 0);
	}
}
