using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CylFollowAni : MonoBehaviour {

    private Vector3 moveR;
    private GameObject mTut, mStart;

    public GameObject objDialog, pathButtonObj, transImage, circles, panel, runeBack, cylFollowAni,
        widget1, widget2, widget3, widgetR1, widgetR2, widgetR3, mTutR, mStartR, tutName;
    private Text dialog;
    public static int left = 1;
	public Image imgBack;
    public static int tutorialState = 0;
    

    void Start() {
        mStart = GameObject.Find("CylinderStart");
        mTut = GameObject.Find("CylinderFollow");
        //tutName = GameObject.Find("LevelName (1)");
        moveR = new Vector3(5.0f, 0.0f, 0.0f);
        dialog = objDialog.GetComponent<Text>();
		pathButtonObj.SetActive(false);
        transImage.SetActive(false);
        circles.SetActive(false);
        widget1.SetActive(false);
        widget2.SetActive(false);
        widget3.SetActive(false);
        widgetR1.SetActive(false);
        widgetR2.SetActive(false);
        widgetR3.SetActive(false);
        imgBack.enabled = false;
        tutName.SetActive(false);

        if (left == 1) { // a quick fix for a null reference error, I couldnt figure out.
            PathTracer.guiScore.enabled = false;
            //PathTracer.guiTime.enabled = false;

        }

        runeBack.SetActive(false);
        panel.SetActive(false);
        cylFollowAni.SetActive(false);
    }

    public void SetToRight() {
        left = 0;
       // Debug.Log("func call " +left);
        tutName.SetActive(false);
    }

    public void playAnimation() {
        //Debug.Log(left);
        dialog.text = "To unlock the rune, first I have to <color=black>place my magic lens</color> on the light. \n Like this!";
        if (left == 1) {
            mStartR.SetActive(false);
            mTutR.SetActive(false);
        }
        else if (left == 0) {
            mTut.SetActive(false);
            mStart.SetActive(false);
        }
        if (left == 1) {
            widget1.SetActive(true);
        }
        else if (left == 0) {
            widgetR1.SetActive(true);
        }
        runeBack.SetActive(true);
        panel.SetActive(true);
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "CylinderMouseTut") {
            if (tutorialState == 0) {
				GradiantLamp.skammekrog = false;
                //mTut.transform.position += moveR;
                //widget1.SetActive(false);
                if (left == 1) {
                    mTut.transform.position += moveR;
                    widget1.SetActive(false);
                }
                else if (left == 0) {
                    mTutR.transform.position -= moveR;
                    widgetR1.SetActive(false);
                }
                cylFollowAni.SetActive(true);
                tutorialState++;
                Audio.audiostate = 5; // plays sound
            }
            if (tutorialState == 2) {
                mStart.SetActive(false);
                //mTut.transform.position += moveR;
                //widget2.SetActive(false);
                if (left == 1) {
                    widget2.SetActive(false);
                    mTut.transform.position += moveR;
                }
                else if (left == 0) {
                    widgetR2.SetActive(false);
                    mTutR.transform.position -= moveR;
                }
                
                tutorialState++;
                Audio.audiostate = 7; // plays sound
            }
            if (tutorialState == 4) {
                GradiantLamp.skammekrog = true;
                dialog.text = "";
                if (left == 1) {
                    widget3.SetActive(false);
                    mTut.SetActive(false);
                    mStart.SetActive(false);
                }
                else if (left == 0) {
                    widgetR3.SetActive(false);
                    mTutR.SetActive(false);
                    mStartR.SetActive(false);
                }
                //widget3.SetActive(false);
                panel.SetActive(false);
                pathButtonObj.SetActive(true);
                tutorialState++;
                Audio.audiostate = 9; // plays sound
            }
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.name == "CylinderMouseTut") {
            if (tutorialState == 1) {
				dialog.text = "Then I have to draw the rune, by <color=black>dragging the magic lens</color> across the stone.";
                //widget2.SetActive(true);
                if (left == 1) {
                    widget2.SetActive(true);
                }
                else if (left == 0) {
                    widgetR2.SetActive(true);
                }
                tutorialState++;
            }
            if (tutorialState == 3) {
                dialog.text = "Look how the <color=black>light changes</color>! It's showing me the way.";
                //widget3.SetActive(true);
                //mStart.SetActive(true);
                // mStart.transform.position += moveR;
                if (left == 1) {
                    widget3.SetActive(true);
                    mStart.SetActive(true);
                    mStart.transform.position += moveR;
                }
                else if (left == 0) {
                    widgetR3.SetActive(true);
                    mStartR.SetActive(true);
                    mStartR.transform.position -= moveR;
                }
                tutorialState++;
            }
        }
    }

    public void pathState() {
        //tutName.SetActive(true);
        //dialog2.text = "Okay this is the real deal! I have to draw this rune starting from the left circle to the right. \n The light will help me stay on track.";
        imgBack.enabled = true;
        transImage.SetActive(true);
        panel.SetActive(false);
        pathButtonObj.SetActive(false);
        circles.SetActive(true);
        GameObject.Find("CylinderMouseTut").transform.position += new Vector3(0.0f, 50.0f, 0.0f); //moves mouse away from screen view
        imgBack.CrossFadeAlpha(0.0f, 2.0f, true);
        tutorialState++;
        Timer.timerFrozen = true;
        tutName.SetActive(true);

    }
}
