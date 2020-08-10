using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

public class Logging : MonoBehaviour {

    private static string URL = "http://www.drakkashi.com/files/p7/_conn.php";
    private static string KEY = "t9XJs206xd";
    private static string dir;

    private static Logging current;

    private WWW www;
    private WWWForm form;

    public Logging()
    {
        current = this;
    }

    public void clear() {
        dir = Application.persistentDataPath + "/data.txt";
        www = new WWW(URL);
        if (File.Exists(dir))
            File.Delete(dir);
    }

    public static void log(string data) {
        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(dir, true))
        {
            sw.WriteLine(data);
        }
    }

    IEnumerator SaveToMySQL()
    {
        www = new WWW(URL, form);
        yield return www;
        string response = www.text;
        Debug.Log("Response: " + response);
    }

    public void upload(string id, int session, int hit, int total, long millis, long timeOffPath, bool rightHanded)
    {
        string dataStr = File.ReadAllText(dir);
        form = new WWWForm();
        form.AddField("key", KEY);
        form.AddField("data", dataStr);

        form.AddField("subject", id);
        form.AddField("session", session);
        form.AddField("hit", hit);
        form.AddField("total", total);
        form.AddField("elapsedTime", millis + "");
        form.AddField("timeOffPath", timeOffPath + "");

        if (rightHanded)
            form.AddField("rightHanded", 1);

        StartCoroutine(SaveToMySQL());
    }

    public static Logging getCurrent()
    {
        return current;
    }
}