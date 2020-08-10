using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Intro : MonoBehaviour {
	//Storyboards
	public Texture2D[] storyTextures = new Texture2D[3];
	private int currentStory = -1;
	private int totalStory = 3;//REMEMBER TO CHANGE THIS TO FIT # OF IMAGES
	public static Texture2D CurrentTex;
	private static Renderer rend;
	public GameObject objDialog;
	public static Text dialog;



	void Start (){
		rend = GetComponent<Renderer> ();
		rend.material.mainTexture = storyTextures[0];
		dialog = objDialog.GetComponent<Text>();

	}

	public void nextStoryboard() {

		if (currentStory < totalStory) {		
			dialog.enabled = true;
			currentStory++;
			CurrentTex = storyTextures [currentStory]; 
			rend.material.mainTexture = CurrentTex; 
		} 
		else if(currentStory == totalStory){
			GameObject.Find("IntroNext").SetActive(false);
			GameObject.Find("StartTutorial").SetActive(true);
			dialog.enabled = false;
		}
		if (currentStory == 0) {
			dialog.text = "This is the grand magical forest. The secrets of the rune magic is hidden inside, " +
				"and only the foolish would ever think to venture there.";
		} else if (currentStory == 1) {
			dialog.text = "Which is why I am going in there! Together with my trusted companion, Sir Whiskers, " +
				"I shall learn the secrets of the runes!";

		} else if (currentStory == 2) {
			dialog.text = "I have to be quick and accurate. The forest does not give up its secrets to just anyone.";
		}
		else if (currentStory ==3){
			dialog.text = "But I have faith. My adventure is just about to start.";
            GameObject.Find("IntroNext").SetActive(false); // new
        }
	}
	
}
