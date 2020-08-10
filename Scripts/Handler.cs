using UnityEngine;
using UnityEngine.UI;
using System;

public class Handler : MonoBehaviour {


    private static int stage = 0;
    private static int state = 0;
    private static long timestampBeg = -1;
    public static long timestampEnd = 0;
    public static long timeOffPath = 0;
    private static int countStart = 1;
    private static int countEnd = 0;
    private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private static data[] dataList = new data[5];
    public static float timeDisplay;

    public struct data {
        public long millis;
        public float accuracy;
        public int count;
    }

    public static void prepare() {
        Logging.getCurrent().clear();
        if (state == 0) {
            Audio.audiostate = 5; // play sound
            PathTracer.toggle(true);
            countStart = PathTracer.countPixels(Color.white); // moved her because: slow in start() in creates a delay! 
            state++;		
			Debug.Log("Preparing for Start");
			if(GradiantLamp.lampIsOn==false)
				GradiantLamp.skammekrog = false;
        }
    }

    public static void start() {
        if (state == 1) {
            state++;
            timestampBeg = getMillis();
            timeOffPath = 0;
			Timer.timerFrozen = false;
            Debug.Log("Starting");
        }
    }

    public static void appendTimeOffPath(long time)
    {
        timeOffPath += time;
    }

    public static void end()
    { // smaller circle
        if (state == 2) {
            Audio.audiostate = 9; // play sound
            state++; 
            timestampEnd = getMillis();
            countEnd = PathTracer.countPixels(Color.white); // slow function creates a delay! Easy solution DONE: calls function when mouse moves out of each inner circle.

            dataList[stage] = new data();
            dataList[stage].millis = timestampEnd - timestampBeg;
            dataList[stage].accuracy = (countStart - countEnd) * 100.0f / countStart ;
            dataList[stage].count = countEnd;
            Logging.getCurrent().upload(
                    textID.getTextID(),
                    PathTracer.currentLevel,
                    Mathf.Abs(countEnd- countStart),
                    countStart,
                    timestampEnd - timestampBeg,
                    timeOffPath,
                    RightORLeft.isRightHand
                );

            Debug.Log("Ending");
            Debug.Log("Time: " + (dataList[stage].millis / 1000.0f));
            Debug.Log("Accuracy: " + dataList[stage].accuracy);
           // timeDisplay = dataList[stage].millis / 1000.0f;
            timeDisplay = timeOffPath / 1000.0f;
            PathTracer.displayScore();
			ChangePath.showInfoButton();
			Timer.timerFrozen = true;
			if(GradiantLamp.lampIsOn==false)
				GradiantLamp.skammekrog = true;
            timestampBeg = -1;
        }
    }

    public static void reset() {
        state = 0;
    }

    public static long getSeconds() {
        return (long)(DateTime.UtcNow - UnixEpoch).TotalSeconds;
    }

    public static long getMillis() {
        return (long)(DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
    }

    public static float getAccuracy()
    {
        return dataList[stage].accuracy = (countStart - countEnd) * 100.0f / countStart;
    }

    public static float getElapsedTime()
    {
        return (timestampBeg < 0 ? timestampBeg : getMillis() - timestampBeg);
    }


    public static int getStage()
    {
        return stage;
    }


}
