using UnityEngine;
using System.Collections;

public class Slice_2 : MonoBehaviour
{
    private GameObject hat, body, head, arm, feet, player, cha,spark2, boat,scroll,root,leftfoot,ladder;
    public bool SliceState, keylock,armtmp,bodytmp,lv5reset,scrolltmp,isscrolled;
    public bool ArmSlice, BodySlice,ScrollSlice,slicelock;
    private bool lv0sliceboat,lv0reset,lv2reset;

    private Vector3 off1, off2, off3, off4, off5, off6, off_fall_body,off_fall_arm;

    //arm,body,head,feet,hat
    // Use this for initialization
    void Start()
    {
        root = GameObject.Find("Root");
        SliceState = false;
        player = GameObject.FindWithTag("player");
        player.SetActive(true);
        body = GameObject.FindWithTag("body");
        body.SetActive(false);
        arm = GameObject.FindWithTag("arm");
        arm.SetActive(false);
        head = GameObject.FindWithTag("head");
        head.SetActive(false);
        feet = GameObject.FindWithTag("feet");
        feet.SetActive(false);
        hat = GameObject.FindWithTag("hat");
        hat.SetActive(false);
        scroll = GameObject.FindWithTag("scroll");
        leftfoot = root.transform.Find("LF").gameObject;
        cha = GameObject.FindWithTag("char");
        cha.SetActive(true);
        ladder = root.transform.Find("ladder").gameObject;
        slicelock = false;
        off1.x = 4f;
        off1.y = 0;
        off1.z = 0;
        off2.x = 0f;
        off2.y = 0;
        off2.z = 0;
        off3.x = 2f;
        off3.y = 0f;
        off3.z = 0;
        off4.x = 2f;
        off4.y = -2f;
        off4.z = 0;
        off5.x = 2f;
        off5.y = 2f;
        off5.z = 0;
        off6.x = 4f;
        off6.y = 2f;
        off6.z = 0;
        off_fall_body.x = 0.3f;
        off_fall_body.y = -1.4f;
        off_fall_body.z = 0;
        off_fall_arm.x = -0.35f;
        off_fall_arm.y = -1.53f;
        off_fall_arm.z = 0;
        keylock = false;
        lv5reset = false;
        lv0sliceboat = false;
        lv2reset = false;
        lv0reset = false;
    }

    // Update is called once per frame
    void Update()
    {
        spark2 = root.transform.Find("spark2").gameObject;
        boat = root.transform.Find("BuildBoat").gameObject;
        if (player.GetComponent<RolerController2>().level == 5)
        {
            isscrolled = true;
        }
        if (Input.GetKeyDown(KeyCode.C) && !slicelock)
        {
            
                if (!SliceState)
                {
                    SliceState = true;
                    cha.SetActive(false);
                    if (transform.position.x > -106 && transform.position.x < -100 && player.GetComponent<RolerController2>().level == 0 && !lv0sliceboat)
                    {

                        if (spark2.activeInHierarchy)
                        {
                            spark2.SetActive(false);
                        }
                        if (boat.activeInHierarchy)
                        {
                            boat.SetActive(false);
                        }

                        arm.SetActive(true);
                        arm.transform.Rotate(0, 0, -140);
                        body.SetActive(true);
                        body.transform.Rotate(0,0,-70);
                        lv0sliceboat = true;
                    }
                    
                
                    if (SliceState)
                    {
                        
                        leftfoot.SetActive(false);
                    }
                    
                    if (transform.position.x > -88.6 && transform.position.x < 88.4 &&player.GetComponent<RolerController2>().level==2)
                    {
                        if (spark2.activeInHierarchy)
                        {
                            spark2.SetActive(false);
                        }
                        if (boat.activeInHierarchy)
                        {
                            boat.SetActive(false);
                        }
                    
                        arm.SetActive(true);
                        body.SetActive(true);
                        arm.transform.position = transform.position + off_fall_arm;
                        body.transform.position = transform.position + off_fall_body;
                    }

                    
                    body.SetActive(true);
                    if (!bodytmp)
                    {
                        body.transform.position = player.transform.position + off2;
                    }


                    //body_slice.SetActive(false);

                    arm.SetActive(true);
                    if (!armtmp)
                    {
                        arm.transform.position = player.transform.position + off1;
                    }
                    if (isscrolled)
                    {
                        scroll.SetActive(true);
                        if (!scrolltmp)
                        {
                            scroll.transform.position = player.transform.position + off6;
                        }
                    }

                    //arm_slice.SetActive(false);
                    head.SetActive(true);
                    head.transform.position = player.transform.position + off3;
                    //head_slice.SetActive(false);
                    feet.SetActive(true);
                    feet.transform.position = player.transform.position + off4;
                    hat.SetActive(true);
                    hat.transform.position = player.transform.position + off5;
                    //feet_slice.SetActive(false);
                   



                }
                else
                {
                    cha.SetActive(true);

                    if (!armtmp)
                    {
                        arm.SetActive(false);
                    }
                    if (!bodytmp)
                    {
                        body.SetActive(false);
                    }
                    if (!scrolltmp)
                    {
                        scroll.SetActive(false);
                    }
                    //arm_slice.SetActive(true);
                    feet.SetActive(false);
                    //feet_slice.SetActive(true);
                    head.SetActive(false);
                    //head_slice.SetActive(true);
                    hat.SetActive(false);

                    SliceState = false;

                }

                if (armtmp)
                {
                    ArmSlice = true;
                }
                if (bodytmp)
                {
                    BodySlice = true;
                }
                if (scrolltmp)
                {
                    ScrollSlice = true;
                }
            
            


        }
        if (SliceState)
        {


            if ((armtmp || bodytmp || scrolltmp) && Input.GetKey(KeyCode.F))
            {
                armtmp = false;
                ArmSlice = false;
                bodytmp = false;
                BodySlice = false;
                scrolltmp = false;
                if (player.GetComponent<RolerController2>().level <= 1 && !lv0reset)
                {
                    arm.transform.Rotate(0, 0, 140);
                    body.transform.Rotate(0, 0, 70);
                    lv0reset = true;
                }
                if (player.GetComponent<RolerController2>().level == 2 && !lv2reset)
                {
                    arm.transform.Rotate(0, 0, 140);
                    body.transform.Rotate(0, 0, 70);
                    lv2reset = true;
                }
                if (player.GetComponent<RolerController2>().level >= 5)
                {
                    ScrollSlice = false;
                    scroll.transform.position = player.transform.position + off6;
                }
                
                body.transform.position = player.transform.position + off2;
                arm.transform.position = player.transform.position + off1;
                if (player.GetComponent<RolerController2>().level == 6)
                {
                    ladder.SetActive(false);
                    player.GetComponent<RolerController2>().level = 5;
                    scroll.GetComponent<ScrollCheck>().laddercheck = false;
                }
                
            }
            if (arm.transform.position != player.transform.position + off1)
            {

                armtmp = true;
            }
            if (body.transform.position != player.transform.position + off2)
            {
                bodytmp = true;
            }
            if (scroll.transform.position != player.transform.position + off6)
            {
                scrolltmp = true;
            }
        }
        if (player.GetComponent<RolerController2>().level == 5 && (!lv5reset))
        {
            armtmp = false;
            bodytmp = false;
            ArmSlice = false;
            BodySlice = false;
            scrolltmp = false;
            ScrollSlice = false;
            scroll.transform.position = player.transform.position + off6;
            body.transform.position = player.transform.position + off2;
            arm.transform.position = player.transform.position + off1;
            arm.transform.Rotate(0, 0, 30);
            body.transform.Rotate(0, 0, 70);
            scroll.transform.Rotate(0, 0, -90);
            lv5reset = true;
        }
        if (player.GetComponent<RolerController2>().level == 2)
        {
            arm.layer = 12;
            body.layer = 12;
            head.layer = 12;
            feet.layer = 12;
        }
        if (player.GetComponent<RolerController2>().level == 5)
        {
            arm.layer = 9;
            body.layer = 9;
            head.layer = 9;
            feet.layer = 9;
        }
        if (transform.position.x <= -105 && transform.position.x >= -113.5 && GetComponent<RolerController2>().level == 0)
        {
            slicelock = true;
        }
        if (transform.position.x >= -105 && GetComponent<RolerController2>().level == 0)
        {
            slicelock = false;
        }
        if (transform.position.x >= -98.3 && transform.position.x <= -88.5 && GetComponent<RolerController2>().level == 1)
        {
            slicelock = true;
        }
        if (transform.position.x >= -88.5 && GetComponent<RolerController2>().level == 2)
        {
            slicelock = false;
        }
    }
}

