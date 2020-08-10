using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {

    public static bool mouseEnabled = true;
    public int id;

    void OnCollisionEnter(Collision col) { //OnTouchDown() {
		if (col.gameObject.name == "CylinderMouse" && id==1
		    ||col.gameObject.name == "CylinderMouse2" && id==1
		    ||col.gameObject.name == "CylinderMouse3" && id==1
		    ||col.gameObject.name == "CylinderMouse4" && id==1
            || col.gameObject.name == "CylinderMouseTut" && id == 1) {
            Handler.prepare();
            mouseEnabled = false;
            //Color colorStart = new Color(0.0F, 0.0F, 0.0F, 1.0F);
            //Color colorEnd = new Color(0.0F, 0.0F, 0.0F, 0.0F);
            //popUpRend.color = Color.Lerp(colorStart, colorEnd, Mathf.PingPong(Time.time, 1.0F) / 1.0F);
            //Debug.Log("last: " + popUpRend.color);
            NewLevel.popUp.SetActive(false);
        }
        else if (col.gameObject.name == "CylinderMouse" && id == 2
                 || col.gameObject.name == "CylinderMouse2" && id == 2
                 || col.gameObject.name == "CylinderMouse3" && id == 2
                 || col.gameObject.name == "CylinderMouse4" && id == 2
                 || col.gameObject.name == "CylinderMouseTut" && id == 2) { // moved here to cheat the delay! BUT: I can make it draw a bit more in the delay, just a tiny bit.
            Handler.end();
            NewLevel.popupPaper.SetActive(true);
        }
    }
    void OnCollisionExit(Collision col) {//OnTouchExit() {
        if (id == 0 && mouseEnabled)
            Handler.start();
    }

    void Update() {
        mouseEnabled = true;
    }
}
