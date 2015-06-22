using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

    public Texture Begin, Quit, Setup,Continue,cancel,music, sound;
    public GUISkin myskin;
    GameObject canvas, panel,maincamera,blurcamera,bg,player;
    private bool issetting;
    private float musicVol, soundVol;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        //panel = canvas.transform.Find("Panel").gameObject;
        issetting = false;
      //  maincamera = GameObject.Find("Main Camera");
       // blurcamera = GameObject.Find("BlurCamera");
      //  bg = GameObject.Find("background");
        //player = GameObject.Find("player");
        //bg.SetActive(false);
        //player.SetActive(false);
    }
    void OnGUI()
    {
        
        const int buttonWidth = 240;
        const int buttonHeight = 160;
        GUI.skin = myskin;
        GUI.backgroundColor = Color.clear;
        
        //GUI.backgroundColor = Color.clear;
        //blurcamera.transform.position = maincamera.transform.position;

        if (GUI.Button(new Rect(Screen.width - 80, Screen.height - 80, 80, 80), Setup))
        {
            if (!issetting)
            {
                issetting = true;

            }
            else
            {
                issetting = false;

            }


        }
        if (!issetting)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (Screen.height / 2) - (buttonHeight / 2), buttonWidth, buttonHeight), Begin))
            {
                Application.LoadLevel("Scene2");
            }

            if (GUI.Button(new Rect(Screen.width - 80, 0, 80, 80), cancel)) 
            {
                Application.Quit();
            }
        }
        else
        {
            //GUI.TextArea(new Rect(Screen.width / 2 - 200, Screen.height / 2, 130, 20), "Enviromental Sound", 100);
            GUI.backgroundColor = Color.white;
            musicVol = GUI.HorizontalSlider(new Rect(Screen.width / 2, Screen.height / 2 - 45, 240, 40), musicVol, 0.0F, 1.0F);
            soundVol = GUI.HorizontalSlider(new Rect(Screen.width / 2 , Screen.height / 2+40, 240, 40), soundVol, 0.0F, 1.0F);
            GUI.backgroundColor = Color.clear;
            GUI.DrawTexture(new Rect(Screen.width / 2 - 200, Screen.height / 2-85, 150, 80), music,ScaleMode.ScaleToFit,true, 0);
            GUI.DrawTexture(new Rect(Screen.width / 2 - 200, Screen.height / 2 +5, 150, 80), sound, ScaleMode.ScaleToFit, true, 0);
           
           
            if (GUI.Button(new Rect(Screen.width - 80, 0, 80, 80), cancel))
            {
                issetting = false;
            }
          
            
        }
        
     

    }
}
