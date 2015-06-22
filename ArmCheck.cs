using UnityEngine;
using System.Collections;

public class ArmCheck : MonoBehaviour
{
    GameObject part, arm;
    public bool check_arm,check_arm_2;
    private bool rotated,rotated_2,readd;
    private Vector3 pos1,pos2,pos3,pos_mo;
    GameObject player,waterfallconst,waterfall;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("player");
        waterfallconst = GameObject.FindWithTag("fallconst");
        waterfall = GameObject.FindWithTag("fallhide");
        part = GameObject.Find("part");
        arm = part.transform.Find("Arm").gameObject;
        check_arm = false;
        check_arm_2 = false;
        rotated = false;
        rotated_2 = false;
        pos1.x = -114.0856f;
        pos1.y = 16.58739f;
        pos1.z = -11.13037f;
        pos2.x = -98.70377f;
        pos2.y = 16.58739f;
        pos2.z = -11.13037f;
        pos3.x = -86.34815f;
        pos3.y = 18.55484f;
        pos3.z = 0;
        pos_mo.x = -33;
        pos_mo.y = -7;
        pos_mo.z = -11.13037f;
        readd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<RolerController2>().level == 0)
        {
            if ((transform.position.x > -114.3 && transform.position.x < -113.8) && (transform.position.y > 16.3 && transform.position.y < 16.8))
            {
                check_arm = true;
                if (!rotated)
                {
                    transform.Rotate(0, 0, -140);
                    rotated = true;

                }


            }
            else
            {
                if (rotated)
                {
                    transform.Rotate(0, 0, 140);
                    rotated = false;
                }
                check_arm = false;
            }
            if (rotated)
            {
                transform.position = pos1;
            }
        }
        else if (player.GetComponent<RolerController2>().level == 1)
        {
            if ((transform.position.x > -99 && transform.position.x < -98.4) && (transform.position.y > 16.3 && transform.position.y < 16.8))
            {
                check_arm = true;
                if (!rotated)
                {
                    transform.Rotate(0, 0, -140);
                    rotated = true;

                }


            }
            else
            {
                if (rotated)
                {
                    transform.Rotate(0, 0, 140);
                    rotated = false;
                }
                check_arm = false;
            }
            if (rotated)
            {
                transform.position = pos2;
            }
        }
        

            if (transform.position.x > -87 && transform.position.x < -85 && transform.position.y >18 && transform.position.y < 19)
            {
                if (!rotated_2)
                {
                    transform.Rotate(0, 0, 110);
                    
                    rotated_2 = true;
                   
                    
                }
                transform.position = pos3;
                check_arm_2 = true;

              
            }
            else
            {
                if (rotated_2)
                {
                   
                    check_arm_2 = false;

                }
            }
            if (player.GetComponent<RolerController2>().level == 9)
            {
                if (transform.position.x > -35 && transform.position.x < -31 && transform.position.y > -8 && transform.position.y < -6)
                {
                    //transform.position = pos_mo;
                    player.GetComponent<RolerController2>().level = 10;
                }
            }
            if (player.GetComponent<RolerController2>().level == 10)
            {
                transform.position = pos_mo;
                Destroy(arm.GetComponent("DragMove2"));
                arm.renderer.material.color = Color.white;
            }
            if (player.GetComponent<RolerController2>().level > 10 && !readd)
            {
                arm.AddComponent("DragMove2");
                readd = true;
            }
        
    }
}

