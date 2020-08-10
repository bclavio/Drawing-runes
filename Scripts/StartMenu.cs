using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	public static int testState;

    public void ChangeToState(){
        testState = textID.stateNr;
        Application.LoadLevel("Scene1");
    }	
}
	
