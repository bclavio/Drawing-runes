using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasToggle : MonoBehaviour {

    public Image imgStart;
    public Image imgBack;
    public GameObject cyl, restartButton, diaText;//, diaPanel;
    private Vector3 startMouseMove;
    //public ParticleSystem ParticleDown;

    void Start() {
        diaText.SetActive(false);
        //diaPanel.SetActive(false);
        //PathTracer.guiTime.enabled = false; 
        PathTracer.guiScore.enabled = false;       
        //restartButton.SetActive(false);
    }
    public void CanvasHide() {
        imgStart.CrossFadeAlpha(0.0f, 0.5f, true);
        imgBack.CrossFadeAlpha(0.0f, 2.0f, true);
        //ParticleDown.Clear(true);
        cyl.SetActive(false);
        diaText.SetActive(true);
        //restartButton.SetActive(true);
        //diaPanel.SetActive(true);
        GameObject.Find("TextAnimation").SetActive(false);
        
        GameObject.Find("CylinderMouseTut").transform.position += new Vector3(0.0f, 20.0f, 0.0f); //moves mouse away from screen view
    }
}
