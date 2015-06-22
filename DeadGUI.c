using UnityEngine;
using System.Collections;

public class DeadGUI : MonoBehaviour {
    GameObject blurcamera, maincamera, camroot;
	// Use this for initialization
	void Start () {
        camroot = GameObject.Find("Camera");
        blurcamera = camroot.transform.Find("BlurCamera2").gameObject;
        blurcamera.SetActive(false);
        maincamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        const int buttonWidth = 120;
        const int buttonHeight = 80;
        blurcamera.SetActive(true);
        blurcamera.transform.position = maincamera.transform.position;
        Time.timeScale = 0;
        GUI.TextArea(new Rect(Screen.width / 2 - 200, Screen.height / 3 - 100, 400, 200), "You are dead!");
        if(GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (3 * Screen.height / 4) - (buttonHeight / 2), buttonWidth, buttonHeight), "RESTART"))
        {
            
            Application.LoadLevel("Scene2");
        }
    }
}
