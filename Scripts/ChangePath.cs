using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangePath : MonoBehaviour {
    //INFOTOGGLE
    public GameObject infoTextObject, infoPanelObject, infoTextlvl1Object;
    public static GameObject infoButton, infoButton2, infoButton3, infoButton4, infoButton5, infoButton6, infoImage1, infoImage2, infoImage3, infoImage4, infoImage5, levelNameObj;
    public static Image infoPanel;
    public static Text infoText, infoTextlvl1, lvlName;
    private int infoNr;

    //PATHCHANGER
    public static int typeOfPath = 1;//1== lens, 2==offset finger, 3== lamp finger, 4==offset widget, 5 == lamp widget
    public GameObject lamp, lampCube, offsetLamp, mouse;
    GetMouseOfset otherOffSetLamp;
    GradiantLamp otherSkammekrog;

    void Start()
    {
        //INFOTOGGLE
        infoButton = GameObject.Find("InfoButton");
        infoButton2 = GameObject.Find("InfoButton2");
        infoButton3 = GameObject.Find("InfoButton3");
        infoButton4 = GameObject.Find("InfoButton4");
        infoButton5 = GameObject.Find("InfoButton5");
        infoButton6 = GameObject.Find("InfoButton6");

        infoText = infoTextObject.GetComponent<Text>();
        infoTextlvl1 = infoTextlvl1Object.GetComponent<Text>();
        infoPanel = infoPanelObject.GetComponent<Image>();

        levelNameObj = GameObject.Find("LevelName");
        levelNameObj.SetActive(false);
        lvlName = levelNameObj.GetComponent<Text>();

        infoImage1 = GameObject.Find("InfoImage1");
        infoImage2 = GameObject.Find("InfoImage2");
        infoImage3 = GameObject.Find("InfoImage3");
        infoImage4 = GameObject.Find("InfoImage4");
        infoImage5 = GameObject.Find("InfoImage5");

        infoImage1.SetActive(false);
        infoImage2.SetActive(false);
        infoImage3.SetActive(false);
        infoImage4.SetActive(false);
        infoImage5.SetActive(false);

        infoButton.SetActive(false);
        infoButton2.SetActive(false);
        infoButton3.SetActive(false);
        infoButton4.SetActive(false);
        infoButton5.SetActive(false);
        infoButton6.SetActive(false);
        //exitButton.SetActive(false);

        infoText.enabled = false;
        infoTextlvl1.enabled = false;
        infoPanel.enabled = false;



        //PATHCHANGER
        lamp = GameObject.Find("CylinderLamp");
        lampCube = GameObject.Find("CylinderLampCube");
        offsetLamp = GameObject.Find("CylinderMouseOffset");
        mouse = GameObject.Find("CylinderMouse");
        otherOffSetLamp = offsetLamp.GetComponent<GetMouseOfset>();
        otherSkammekrog = mouse.GetComponent<GradiantLamp>();
    }


    public void changePathWithTeststate(int ButtonNr) {
        Debug.Log("This is the state number "+((textID.stateNr % 10)+1));
        switch ((textID.stateNr%10)+1) {         
            case 1:
               // Debug.Log("Case 1");
                switch (ButtonNr) {
                    case 1:
                        //Button 1
                        typeOfPath = 1;
                        showInfo();
                        pathPattern();
                        break;
                    case 2:
                        typeOfPath = 2;
                        showInfo();
                        pathPattern();
                        break;
                    case 3:
                        //Button 3
                        typeOfPath = 5;
                        showInfo();
                        pathPattern();
                        break;
                    case 4:
                        //Button 4
                        typeOfPath = 3;
                        showInfo();
                        pathPattern();
                        break;
                    case 5:
                        //Button 5
                        typeOfPath = 4;
                        showInfo();
                        pathPattern();
                        break;
                    case 6:
                        //Button 5
                        typeOfPath = 6;
                        showInfo();
                        infoButton6.SetActive(false);
                        break;
                }
                
                break;

            case 2:
                // Debug.Log("Case 1");
                switch (ButtonNr)
                {
                    case 1:
                        //Button 1
                        typeOfPath = 2;
                        showInfo();
                        pathPattern();
                        break;
                    case 2:
                        typeOfPath = 3;
                        showInfo();
                        pathPattern();
                        break;
                    case 3:
                        //Button 3
                        typeOfPath = 1;
                        showInfo();
                        pathPattern();
                        break;
                    case 4:
                        //Button 4
                        typeOfPath = 4;
                        showInfo();
                        pathPattern();
                        break;
                    case 5:
                        //Button 5
                        typeOfPath = 5;
                        showInfo();
                        pathPattern();
                        break;
                    case 6:
                        //Button 5
                        typeOfPath = 6;
                        showInfo();
                        infoButton6.SetActive(false);
                        break;
                }

                break;

            case 3:
                // Debug.Log("Case 1");
                switch (ButtonNr)
                {
                    case 1:
                        //Button 1
                        typeOfPath = 3;
                        showInfo();
                        pathPattern();
                        break;
                    case 2:
                        typeOfPath = 4;
                        showInfo();
                        pathPattern();
                        break;
                    case 3:
                        //Button 3
                        typeOfPath = 2;
                        showInfo();
                        pathPattern();
                        break;
                    case 4:
                        //Button 4
                        typeOfPath = 5;
                        showInfo();
                        pathPattern();
                        break;
                    case 5:
                        //Button 5
                        typeOfPath = 1;
                        showInfo();
                        pathPattern();
                        break;
                    case 6:
                        //Button 5
                        typeOfPath = 6;
                        showInfo();
                        infoButton6.SetActive(false);
                        break;
                }

                break;

            case 4:
                // Debug.Log("Case 1");
                switch (ButtonNr)
                {
                    case 1:
                        //Button 1
                        typeOfPath = 4;
                        showInfo();
                        pathPattern();
                        break;
                    case 2:
                        typeOfPath = 5;
                        showInfo();
                        pathPattern();
                        break;
                    case 3:
                        //Button 3
                        typeOfPath = 3;
                        showInfo();
                        pathPattern();
                        break;
                    case 4:
                        //Button 4
                        typeOfPath = 1;
                        showInfo();
                        pathPattern();
                        break;
                    case 5:
                        //Button 5
                        typeOfPath = 2;
                        showInfo();
                        pathPattern();
                        break;
                    case 6:
                        //Button 5
                        typeOfPath = 6;
                        showInfo();
                        infoButton6.SetActive(false);
                        break;
                }

                break;


            case 5:
                // Debug.Log("Case 1");
                switch (ButtonNr)
                {
                    case 1:
                        //Button 1
                        typeOfPath = 5;
                        showInfo();
                        pathPattern();
                        break;
                    case 2:
                        typeOfPath = 1;
                        showInfo();
                        pathPattern();
                        break;
                    case 3:
                        //Button 3
                        typeOfPath = 4;
                        showInfo();
                        pathPattern();
                        break;
                    case 4:
                        //Button 4
                        typeOfPath = 2;
                        showInfo();
                        pathPattern();
                        break;
                    case 5:
                        //Button 5
                        typeOfPath = 3;
                        showInfo();
                        pathPattern();
                        break;
                    case 6:
                        //Button 5
                        typeOfPath = 6;
                        showInfo();
                        infoButton6.SetActive(false);
                        break;
                }

                break;


            case 6:
                // Debug.Log("Case 1");
                switch (ButtonNr)
                {
                    case 1:
                        //Button 1
                        typeOfPath = 4;
                        showInfo();
                        pathPattern();
                        break;
                    case 2:
                        typeOfPath = 3;
                        showInfo();
                        pathPattern();
                        break;
                    case 3:
                        //Button 3
                        typeOfPath = 5;
                        showInfo();
                        pathPattern();
                        break;
                    case 4:
                        //Button 4
                        typeOfPath = 2;
                        showInfo();
                        pathPattern();
                        break;
                    case 5:
                        //Button 5
                        typeOfPath = 1;
                        showInfo();
                        pathPattern();
                        break;
                    case 6:
                        //Button 5
                        typeOfPath = 6;
                        showInfo();
                        infoButton6.SetActive(false);
                        break;
                }

                break;

            case 7:
                // Debug.Log("Case 1");
                switch (ButtonNr)
                {
                    case 1:
                        //Button 1
                        typeOfPath = 5;
                        showInfo();
                        pathPattern();
                        break;
                    case 2:
                        typeOfPath = 4;
                        showInfo();
                        pathPattern();
                        break;
                    case 3:
                        //Button 3
                        typeOfPath = 1;
                        showInfo();
                        pathPattern();
                        break;
                    case 4:
                        //Button 4
                        typeOfPath = 3;
                        showInfo();
                        pathPattern();
                        break;
                    case 5:
                        //Button 5
                        typeOfPath = 2;
                        showInfo();
                        pathPattern();
                        break;
                    case 6:
                        //Button 5
                        typeOfPath = 6;
                        showInfo();
                        infoButton6.SetActive(false);
                        break;
                }

                break;


            case 8:
                // Debug.Log("Case 1");
                switch (ButtonNr)
                {
                    case 1:
                        //Button 1
                        typeOfPath = 1;
                        showInfo();
                        pathPattern();
                        break;
                    case 2:
                        typeOfPath = 5;
                        showInfo();
                        pathPattern();
                        break;
                    case 3:
                        //Button 3
                        typeOfPath = 2;
                        showInfo();
                        pathPattern();
                        break;
                    case 4:
                        //Button 4
                        typeOfPath = 4;
                        showInfo();
                        pathPattern();
                        break;
                    case 5:
                        //Button 5
                        typeOfPath = 3;
                        showInfo();
                        pathPattern();
                        break;
                    case 6:
                        //Button 5
                        typeOfPath = 6;
                        showInfo();
                        infoButton6.SetActive(false);
                        break;
                }

                break;



            case 9:
                // Debug.Log("Case 1");
                switch (ButtonNr)
                {
                    case 1:
                        //Button 1
                        typeOfPath = 2;
                        showInfo();
                        pathPattern();
                        break;
                    case 2:
                        typeOfPath = 1;
                        showInfo();
                        pathPattern();
                        break;
                    case 3:
                        //Button 3
                        typeOfPath = 3;
                        showInfo();
                        pathPattern();
                        break;
                    case 4:
                        //Button 4
                        typeOfPath = 5;
                        showInfo();
                        pathPattern();
                        break;
                    case 5:
                        //Button 5
                        typeOfPath = 4;
                        showInfo();
                        pathPattern();
                        break;
                    case 6:
                        //Button 5
                        typeOfPath = 6;
                        showInfo();
                        infoButton6.SetActive(false);
                        break;
                }

                break;


            case 10:
                // Debug.Log("Case 1");
                switch (ButtonNr)
                {
                    case 1:
                        //Button 1
                        typeOfPath = 3;
                        showInfo();
                        pathPattern();
                        break;
                    case 2:
                        typeOfPath = 2;
                        showInfo();
                        pathPattern();
                        break;
                    case 3:
                        //Button 3
                        typeOfPath = 4;
                        showInfo();
                        pathPattern();
                        break;
                    case 4:
                        //Button 4
                        typeOfPath = 1;
                        showInfo();
                        pathPattern();
                        break;
                    case 5:
                        //Button 5
                        typeOfPath = 5;
                        showInfo();
                        pathPattern();
                        break;
                    case 6:
                        //Button 5
                        typeOfPath = 6;
                        showInfo();
                        infoButton6.SetActive(false);
                        break;
                }

                break;


        }
    
    }

    public void pathPattern(){
        if (typeOfPath == 1)
        {
            Debug.Log("Widget");
            lamp.SetActive(false);
            lampCube.SetActive(false);
            offsetLamp.SetActive(false);
            GradiantLamp.skammekrog = false;
            MirrorLamps.isOn = false;
            GradiantLamp.lampIsOn = false;
        }
        else if (typeOfPath == 2) {
            Debug.Log("Finger offset");
            lamp.SetActive(false);
            lampCube.SetActive(false);
            offsetLamp.SetActive(true);
            
            GetMouseOfset.offsetOn = true;
            otherOffSetLamp.toggleOffset();
           // otherSkammekrog.skammekrog = true;
            MirrorLamps.isOn = true;

            GradiantLamp.lampIsOn = true;
        }
        else if (typeOfPath == 3){
            Debug.Log("finger lamp");

            lamp.SetActive(true);
            lampCube.SetActive(true);
            offsetLamp.SetActive(false);
            
            GradiantLamp.lampIsOn = true;
            MirrorLamps.isOn = true;

            GradiantLamp.skammekrog = true;
        }
        else if (typeOfPath == 4)
        {
            Debug.Log("widget offset");
            lamp.SetActive(false);
            lampCube.SetActive(false);
            offsetLamp.SetActive(true);

            GetMouseOfset.offsetOn = true;
            otherOffSetLamp.toggleOffset();
            // otherSkammekrog.skammekrog = true;
            MirrorLamps.isOn = true;

            GradiantLamp.lampIsOn = true;
        }
        else if (typeOfPath == 5)
        {
            Debug.Log("Widget lamp");

            lamp.SetActive(true);
            lampCube.SetActive(true);
            offsetLamp.SetActive(false);

            GradiantLamp.lampIsOn = true;
            MirrorLamps.isOn = true;

            GradiantLamp.skammekrog = true;
        }

    }

    public static void showInfoButton()
    {
        if (PathTracer.currentLevel == 1)
            infoButton.SetActive(true);
        else if (PathTracer.currentLevel == 2)
            infoButton2.SetActive(true);
        else if (PathTracer.currentLevel == 3)
            infoButton3.SetActive(true);
        else if (PathTracer.currentLevel == 4)
            infoButton4.SetActive(true);
        else if (PathTracer.currentLevel == 5)
            infoButton5.SetActive(true);
        else if (PathTracer.currentLevel == 6)
            infoButton6.SetActive (true);
    }

    public void showInfo(){
        infoNr = ChangePath.typeOfPath;
        infoButton.SetActive(false);
        infoButton2.SetActive(false);
        infoButton3.SetActive(false);
        infoButton4.SetActive(false);
        infoButton5.SetActive(false);

        infoText.enabled = true;
        infoTextlvl1.enabled = true;
        infoPanel.enabled = true;
        levelNameObj.SetActive(true);

        if (PathTracer.currentLevel == 0){
            infoText.text = "Hello world";
            //infoTextlvl1.text = "Keep your eyes open for the line, it will disappear!";
            //infoImage1.SetActive(true);
        }
        else if (PathTracer.currentLevel == 6)
        {
            infoTextlvl1.enabled = false;
            infoText.text = "That was it for the test. Thank you for your participation.";
        }
        else if (PathTracer.currentLevel <= 5 && PathTracer.currentLevel >= 1)
        {
            //  if (infoNr >5)
            //	infoNr = 1;
            if (PathTracer.currentLevel == 1)
            {
                infoTextlvl1.text = "Keep your eyes open for the line, it will disappear!";
                infoTextlvl1.enabled = true;
            }
            else
                infoTextlvl1.enabled = false;


            if (infoNr == 1)
            {
                infoText.text = "<color=black>LENS </color>\nFor your next task, use the magic lens.";
                lvlName.text = "LENS";
                infoImage1.SetActive(true);
                Debug.Log(PathTracer.currentLevel);
                
                // Debug.Log("1: infoNr = " + infoNr);

            }
            else if (infoNr == 2)
            {
                //infoTextlvl1.enabled = false;
                infoText.text = "<color=black>FINGER OFFSET</color> \nFor your next task, the light feedback will have an offset from you finger.";
                lvlName.text = "FINGER OFFSET";                
                infoImage2.SetActive(true);
                Debug.Log("2: infoNr = " + infoNr);
                

            }
            else if (infoNr == 3)
            {
                //infoTextlvl1.enabled = false;
                infoText.text = "<color=black>FINGER CORNER</color> \nFor your next task, use your finger with the light feedback in the corner.";
                lvlName.text = "FINGER CORNER";
                infoImage3.SetActive(true);
            }
            else if (infoNr == 4)
            {
                //infoTextlvl1.enabled = false;
                infoText.text = "<color=black>GEM OFFSET</color> \nFor your next task, the light feedback will have an offset from the magic gem.";
                lvlName.text = "GEM OFFSET";
                infoImage4.SetActive(true);
            }
            else if (infoNr == 5)
            {
                //infoTextlvl1.enabled = false;
                infoText.text = "<color=black>GEM CORNER</color> \nFor your next task, use the magic gem with the light feedback in the corner.";
                lvlName.text = "GEM CORNER";
                infoImage5.SetActive(true);
            }

        }




    }

}
