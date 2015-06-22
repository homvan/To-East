using UnityEngine;
using System.Collections;

public class ui_2 : MonoBehaviour {
    GameObject blurcamera,maincamera;
    public Texture setup,cancel,quit,sound,music;
    private AudioSource fall;
    public GUISkin myskin;
    private float alpha,musicVol,soundVol;
    private bool addblur;
   
    GameObject canvas, panel;
    public bool issetting;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        panel = canvas.transform.Find("Panel").gameObject;
        panel.SetActive(false);
        fall = GameObject.Find("fallconst").GetComponent<AudioSource>();
        soundVol = 0.5f;
        musicVol = 0.5f;
        issetting = false;
        blurcamera = GameObject.Find("BlurCamera");
        blurcamera.SetActive(false);
        maincamera = GameObject.Find("Main Camera");
        addblur = false;

    }
    void OnGUI()
    {
        const int buttonWidth = 120;
        const int buttonHeight = 80;
        GUI.skin = myskin;
        GUI.backgroundColor = Color.clear;
        alpha = 0.3f;
        GUI.color = new Color(1f, 1f, 1f, alpha);
        if (GUI.Button(new Rect(Screen.width - 70, Screen.height - 70, 70, 70), setup))
            {
                issetting = true;
               
            }
            if (issetting)
            {
                alpha = 1f;
                GUI.color = new Color(1f, 1f, 1f, alpha);
                blurcamera.SetActive(true);
                blurcamera.transform.position = maincamera.transform.position;
                
               
                if (GUI.Button(new Rect(Screen.width - 70, 0, 70, 70), cancel))
                {
                    issetting = false;
                }
                    


                
                Time.timeScale = 0;
                panel.SetActive(true);
                GUI.backgroundColor = Color.white;
                musicVol = GUI.HorizontalSlider(new Rect(Screen.width / 2, Screen.height / 2 - 45, 240, 40), musicVol, 0.0F, 1.0F);
                soundVol = GUI.HorizontalSlider(new Rect(Screen.width / 2, Screen.height / 2 + 40, 240, 40), soundVol, 0.0F, 1.0F);
                GUI.backgroundColor = Color.clear;
                GUI.DrawTexture(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 85, 150, 80), music, ScaleMode.ScaleToFit, true, 0);
                GUI.DrawTexture(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 5, 150, 80), sound, ScaleMode.ScaleToFit, true, 0);
                fall.volume = soundVol;
                if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (3 * Screen.height / 4) - (buttonHeight / 2), buttonWidth, buttonHeight), quit))
                {
                    Application.LoadLevel("StartMenu");
                }
            }
            else
            {
                Time.timeScale = 1;
                panel.SetActive(false);
                blurcamera.SetActive(false);
           //     addblur = false;
            }
               
        
        
    }
}
