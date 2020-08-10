using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TogglePlanes : MonoBehaviour {

	public Image plane;
	public Image imgBack;

	void Start(){
		plane.enabled = false;
		imgBack.enabled = false;

	}
	public void PlaneShow() {	
		plane.enabled = true;
		imgBack.enabled = true;
	}
	public void PlaneHide() {	
		plane.enabled = false;
		imgBack.enabled = false;
	}
}
