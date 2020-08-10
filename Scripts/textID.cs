using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class textID : MonoBehaviour {

    private static string id;
    public static int stateNr;

    public static string getTextID() {
        return id;
    }

    public void setTextID() {
        GameObject txtIDobj = GameObject.Find("TextID");
        Text txtID = txtIDobj.GetComponent<Text>();
        id = txtID.text;
        stateNr = int.Parse(id);
        Debug.Log("STATENUMBER IS: " + stateNr);
    }
}
