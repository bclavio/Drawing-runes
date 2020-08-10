using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuToggle : MonoBehaviour {
	private static GameObject menu;
	private bool isOn = false;

	// Use this for initialization
	void Start () {
		menu = GameObject.Find ("Panel");
		menu.SetActive(false);
		isOn = false;
	}
	
	public void menuToggle(){
		if(isOn == false){
			menu.SetActive(true);
			isOn = true;
		}
		else{
			isOn = false;
			menu.SetActive(false);
		}
	}
}