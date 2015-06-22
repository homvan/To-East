using UnityEngine;
using System.Collections;

public class cameramove : MonoBehaviour {
    GameObject player,downmt,sprites;
    private Vector3 pos,originpos;
    private bool godown;
    public bool lv7reset,movelock,setlimit;
    private float leftlimit;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("player");
        sprites = GameObject.Find("specialsprites");
        downmt = sprites.transform.Find("downmt").gameObject;
        pos.x = -72.8f;
        pos.y = 0.5f;
        pos.z = -20;
        godown = false;
        lv7reset = false;
        movelock = false;
        setlimit = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<cameratrans>().trans && !setlimit)
        {
            originpos.x = transform.position.x;
            originpos.y = transform.position.y;
            originpos.z = transform.position.z;
            leftlimit = originpos.x - 1;
            setlimit = true;
        }
        if (transform.position.x < leftlimit)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(3 * Time.deltaTime, 0, 0);
            }
        }
        if (transform.position.x > 41.252)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-3 * Time.deltaTime, 0, 0);
            }
        }
        if (transform.position.x >= leftlimit && transform.position.x <= 41.252 && transform.position.y <= 11.37 && transform.position.y > -11.9)
        {
            if (!movelock) {
                if (player.transform.position.x > transform.position.x && transform.position.x <41.2)
                {
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        transform.Translate(3 * Time.deltaTime, 0, 0);
                    }
                }
                if(player.transform.position.x < transform.position.x && transform.position.x > leftlimit+0.1f)
                {
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        transform.Translate(-3 * Time.deltaTime, 0, 0);
                    }
                }
                if (player.transform.position.y < transform.position.y && transform.position.y >-11.8)
                {
                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        transform.Translate(0, -3 * Time.deltaTime, 0);
                    }
                }
                if(player.transform.position.y > transform.position.y && transform.position.y < 11.3)
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        transform.Translate(0, 3 * Time.deltaTime, 0);
                    }
                }
                if (player.GetComponent<RolerController2>().level == 6 || player.GetComponent<RolerController2>().level == 7)
                {
                    if (transform.position.y >= 2.33)
                    {
                        if (Input.GetKeyDown(KeyCode.DownArrow))
                        {
                            transform.Translate(0, -3 * Time.deltaTime, 0);
                        }
                    }
                }
            }
            if (player.GetComponent<RolerController2>().level <= 4)
            {
                if (transform.position.x >= -95.5)
                {
                    movelock = true;
                }
            }
            if (player.GetComponent<RolerController2>().level == 5)
            {
                movelock = false;
            }
            if (downmt.activeInHierarchy && transform.position.y >= 2.33)
            {
                transform.Translate(0, -3 * Time.deltaTime, 0);
            }
            
        }
       
     
	}
}
