using UnityEngine;
using System.Collections;

public class RightORLeft : MonoBehaviour {

	public static bool isRightHand;
	// Use this for initialization
	void Start () {
	
	}
	
	public void isRight(){
		isRightHand = true;
		//Debug.Log ("Is Right is " + isRightHand);
	}	
	public void isLeft(){
		isRightHand = false;		
		//Debug.Log ("Is Right is " + isRightHand);
	}
}
