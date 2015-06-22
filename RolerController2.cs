using UnityEngine;
using System.Collections;

public class RolerController2 : MonoBehaviour {
    public Animator Controller;
    GameObject Head, Hat, Feet, Arm, Body, Player, spark, boat, leftfoot, waterfallconst, waterfall, river,  scroll, ladder, makeladder, downmt, character, egg,mo,gudui1,gudui2,qiuqian_anim,part,root,spark2,bigrock,bigrockcamera,rivermask;
    GameObject choufangzi2, choufangzi3,myGUI,deadGUI,treehole;
    GameObject jump;
    private Vector3 speed3,lf_off,spark2off,sparkoff,spark2_ori,playerinfall,afterqiuqian;
    private bool c_keylock,falllock,lv7_camerareset,spark2_2,fallreset,lv16move,lv17acamera;

    private AnimatorStateInfo stateInfo;
    //小关,初始0，在水中小岛1，到达瀑布2,堵住泉水3，水完全落下4，拿到贴条5,放好梯子6，到悬崖下7,身体进坑8，填坑9,放好胳膊10 翘起磨 11，比方吃12 放好身子13，压死比方 14，搭好秋千15，荡秋千16.荡过去17
    public int level;
    //死亡状态
    public bool isdead,iswalking;
    //复活点
    private Vector3 repos,pos_qiuqian,pos_xuanya,scale_rev,scale_ori,pos_xuanya_ori;
	// Use this for initialization
	void Start () {
        level = 0;
        falllock = false;
        treehole = GameObject.Find("treehole");
        jump = GameObject.Find("jump");
        jump.SetActive(false);
        part = GameObject.Find("part");
        Arm = part.transform.Find("Arm").gameObject;
        Body = part.transform.Find("Arm").gameObject;
        Head = GameObject.FindWithTag("head");
        Hat = GameObject.FindWithTag("hat");
        Feet = GameObject.FindWithTag("feet");
        bigrock = GameObject.Find("p2after");
        scroll = GameObject.FindWithTag("scroll");
        scroll.SetActive(true);
        Player = GameObject.FindWithTag("player");
        leftfoot = GameObject.FindWithTag("leftfoot");
        leftfoot.SetActive(false);
        spark = GameObject.FindWithTag("spark");
        spark.SetActive ( false);
        boat = GameObject.FindWithTag("boat");
        boat.SetActive(false);
        waterfallconst = GameObject.FindWithTag("fallconst");
        waterfallconst.SetActive(true);
        waterfall = GameObject.FindWithTag("fallhide");
        waterfall.SetActive(false);
        river = GameObject.FindWithTag("water");
        rivermask = GameObject.Find("rivermask");
        bigrockcamera = GameObject.Find("bigrockcamera");
        bigrockcamera.SetActive(false);
        ladder = GameObject.FindWithTag("ladder");
        makeladder = GameObject.FindWithTag("makeladder");
        ladder.SetActive(false);
        makeladder.SetActive(false);
        downmt = GameObject.FindWithTag("downmt");
        downmt.SetActive(false);
        character = Player.transform.Find("character").gameObject;
        egg = GameObject.FindWithTag("egg");
        mo = GameObject.FindWithTag("mo");
        gudui1 = GameObject.FindWithTag("gudui1");
        gudui1.SetActive(true);
        gudui2 = GameObject.FindWithTag("gudui2");
        gudui2.SetActive(false);
        qiuqian_anim = GameObject.FindWithTag("qiuqian_anim");
        qiuqian_anim.SetActive(false);
        root = GameObject.Find("Root");
        //newpf = GameObject.Find("newpf");
        choufangzi2 = GameObject.Find("choufangzi2");
        choufangzi3 = GameObject.Find("choufangzi3");
        //newpf.SetActive(false);
        deadGUI = GameObject.Find("DeadGUI");
        deadGUI.SetActive(false);
        spark2 = root.transform.Find("spark2").gameObject;
        lf_off.x = -(115.0094f-114.9062f)-0.15f;
        lf_off.y = -(18.13632f-17.0539f);
        lf_off.z = 0f;
        pos_qiuqian.x = 22.42332f;
        pos_qiuqian.y = -12.34812f;
        pos_qiuqian.z = -11.13037f;
        pos_xuanya.x = -79f;
        pos_xuanya.y = 14.43329f;
        pos_xuanya.z = -11.13037f;
        scale_rev.x = -0.5f;
        scale_rev.y = 0.5f;
        scale_rev.z = 1;
        scale_ori.x = 0.5f;
        scale_ori.y = 0.5f;
        scale_ori.z = 1;
        pos_xuanya_ori.x = -89.67648f;
        pos_xuanya_ori.y = 13;
        pos_xuanya_ori.z = -11.13037f;
        spark2.SetActive(false);
        spark2off.x = -0.5f;
        spark2off.y = -0.11f;
        spark2off.z = 0;
        playerinfall.x = -88.48897f;
        playerinfall.y = 18.08584f;
        playerinfall.z = -11.1f;
        fallreset = false;
        afterqiuqian.x = 24.2f;
        afterqiuqian.y = -13.49f;
        afterqiuqian.z = -11.13037f;
        lv16move = false;
        lv17acamera = false;
	}
	
	// Update is called once per frame
    void Update()
    {
        Arm = part.transform.Find("Arm").gameObject;
        Body = part.transform.Find("Body").gameObject;
        if (boat.activeInHierarchy)
        {
            spark2.SetActive(true);
        }
        //---------------角色移动部分------------------
        /*---------------向右走---------------*/
        if (Input.GetKey(KeyCode.RightArrow))
        {


            iswalking = true;
            Controller.SetBool("move", true);
            //河左岸
            if (transform.position.x > -115.67 && transform.position.x <= -114.8)
            {

                transform.Translate(3 * Time.deltaTime * 0.5f, -1.2f * Time.deltaTime * 0.5f, 0);

            }

            //上船

            //过河
            if (boat.activeInHierarchy)
            {


                if (transform.position.x <= -113.5)
                {
                    transform.Translate(Time.deltaTime, 0, 0);
                }
                else if (transform.position.x <= -105)
                {
                    transform.Translate(3 * Time.deltaTime, 0, 0);
                    spark2.transform.Translate(3 * Time.deltaTime, 0, 0);
                    boat.transform.Translate(3 * Time.deltaTime, 0, 0);
                    Body.transform.Translate(3 * Time.deltaTime, 0, 0, Space.World);
                    Arm.transform.Translate(3 * Time.deltaTime, 0, 0, Space.World);
                    spark.SetActive(true);

                    sparkoff.x = boat.transform.position.x - 0.69f;
                    sparkoff.y = boat.transform.position.y + 0.01f;
                    sparkoff.z = 10;
                    spark.transform.position = sparkoff;


                }


            }
            if (transform.position.x <= -103 && transform.position.x >= -105) // 上岸
            {
                transform.Translate(2 * Time.deltaTime, 1 * Time.deltaTime, 0);
            }
            if (transform.position.x >= -103 && transform.position.x <= -100 && !Player.GetComponent<Slice_2>().BodySlice && !Player.GetComponent<Slice_2>().ArmSlice)
            {
                level = 1;

            }
            if (level == 1)
            {
                if (transform.position.x <= -100)
                {
                    transform.Translate(2 * Time.deltaTime, -0.3f * Time.deltaTime, 0);
                }


            }
            //第二次过河
            if (level == 1 && boat.activeInHierarchy)
            {

                //上船
                if (transform.position.x <= -98.3)
                {
                    transform.Translate(Time.deltaTime, -0.3f * Time.deltaTime, 0);
                }
                else if (transform.position.x <= -88.5)
                {

                    transform.Translate(3 * Time.deltaTime, 0, 0);

                    boat.transform.Translate(3 * Time.deltaTime, 0, 0);
                    Body.transform.Translate(3 * Time.deltaTime, 0, 0, Space.World);
                    Arm.transform.Translate(3 * Time.deltaTime, 0, 0, Space.World);
                    spark.SetActive(true);
                    spark2.transform.Translate(3 * Time.deltaTime, 0, 0);


                    sparkoff.x = boat.transform.position.x - 0.69f;
                    sparkoff.y = boat.transform.position.y + 0.01f;
                    sparkoff.z = 10;
                    spark.transform.position = sparkoff;




                }
                else if (transform.position.x >= -88.5)
                {
                    level = 2;
                }
            }

            if (level == 4 || level == 5)
            {
                if (transform.position.x <= -84)
                {
                    transform.Translate(2 * Time.deltaTime, 0, 0);
                }
                else if (transform.position.x >= -84 && transform.position.x <= -79)
                {
                    transform.Translate(3 * Time.deltaTime, 0.45f * Time.deltaTime, 0);
                }
            }
            if (level == 7 && transform.position.x <= -74.6 && transform.position.x >= -80.5)
            {
                transform.Translate(2 * Time.deltaTime, 0, 0);
            }
            if (level >= 9 && transform.position.y > -4.5)
            {
                if (transform.position.x >= -80.6 && transform.position.x <= -65)
                {
                    transform.Translate(3 * Time.deltaTime, 0, 0);
                }
                else if (transform.position.x >= -65 && transform.position.x <= -60.5)
                {
                    transform.Translate(3 * Time.deltaTime, -0.6f * Time.deltaTime, 0);
                }
                else if (transform.position.x >= -60.5 && transform.position.x <= -59.8)
                {
                    transform.Translate(3 * Time.deltaTime, -2.5f * Time.deltaTime, 0);
                }
                else if (transform.position.x >= -59.8 && transform.position.x <= -59.5)
                {
                    transform.Translate(3 * Time.deltaTime, -4.2f * Time.deltaTime, 0);
                }
                else if (transform.position.x >= -59.5 && transform.position.x <= -56.5)
                {
                    transform.Translate(3 * Time.deltaTime, -1.1f * Time.deltaTime, 0);
                }
                else if (transform.position.x >= -56.5 && transform.position.x <= -53.1)
                {
                    transform.Translate(3 * Time.deltaTime, 0.8f * Time.deltaTime, 0);
                }
                else if (transform.position.x >= -53.1 && transform.position.x <= -52.2)
                {

                    transform.Translate(3 * Time.deltaTime, 0, 0);

                }
                else if (transform.position.x >= -52.2 && transform.position.x <= -49.1)
                {
                    transform.Translate(3 * Time.deltaTime, -0.9f * Time.deltaTime, 0);
                }
                else if (transform.position.x >= -49.1 && transform.position.x <= -44.4)
                {
                    transform.Translate(3 * Time.deltaTime, 0.16f * Time.deltaTime, 0);
                }
                else if (transform.position.x >= -44.4 && transform.position.x <= -43.4)
                {

                    transform.Translate(3 * Time.deltaTime, 0, 0);

                }
                else if (transform.position.x >= -43.4 && transform.position.x <= -41.4)
                {
                    transform.Translate(3 * Time.deltaTime, -0.4f * Time.deltaTime, 0);
                }
                else if (transform.position.x >= -41.4 && transform.position.x <= -38.4)
                {
                    transform.Translate(3 * Time.deltaTime, 0, 0);
                }
                else if (transform.position.x >= -38.4 && transform.position.x <= -37.1)
                {
                    transform.Translate(3 * Time.deltaTime, 0.5f * Time.deltaTime, 0);
                }
                else if (transform.position.x >= -37.1 && transform.position.x <= -36.1)
                {
                    transform.Translate(3 * Time.deltaTime, 3.63f * Time.deltaTime, 0);

                }
                else if (transform.position.x >= -36.1 && transform.position.x <= -33)
                {
                    transform.Translate(3 * Time.deltaTime, -0.3f * Time.deltaTime, 0);
                }
            }
            if (level >= 9 && level < 14 && transform.position.y < -6.5)
            {
                if (transform.position.x >= -36.2 && transform.position.x <= -26.2)
                {
                    transform.Translate(3 * Time.deltaTime, 0, 0);
                }

            }
            if ((level == 14 || level == 15) && transform.position.y < -6.5)
            {
                if (transform.position.x >= -36.2 && transform.position.x <= -24)
                {
                    transform.Translate(3 * Time.deltaTime, 0, 0);
                }
                else if (transform.position.x >= -24 && transform.position.x <= -12)
                {
                    transform.Translate(3 * Time.deltaTime, -0.625f * Time.deltaTime, 0);

                }
                else if (transform.position.x >= -12 && transform.position.x <= 0)
                {
                    transform.Translate(3 * Time.deltaTime, -0.425f * Time.deltaTime, 0);
                }
                else if (transform.position.x >= 0 && transform.position.x <= 7)
                {
                    transform.Translate(3 * Time.deltaTime, -0.643f * Time.deltaTime, 0);
                }
                else if (transform.position.x >= 7 && transform.position.x <= 15)
                {
                    transform.Translate(3 * Time.deltaTime, -0.9375f * Time.deltaTime, 0);
                }
            }
            if (level == 17 && transform.position.x >= 25.9 && transform.position.x <= 32 && transform.position.y < -15)
            {
                transform.Translate(3 * Time.deltaTime, 0, 0);
            }
            if (level == 17 && transform.position.y > -6 && transform.position.x >= 30 && transform.position.x <= 58.5)
            {
                transform.Translate(4 * Time.deltaTime, 1 * Time.deltaTime, 0);
            }
        }
        else
        {
            spark.SetActive(false);
            iswalking = false;
            Controller.SetBool("move", false);
            /*---------------向左走---------------*/

            if (Input.GetKey(KeyCode.LeftArrow))
            {


                transform.localScale = scale_rev;

                Controller.SetBool("move", true);
                if (transform.position.x > -115.65 && transform.position.x < -114.3)
                {

                    transform.Translate(-3 * Time.deltaTime * 0.5f, 1.2f * Time.deltaTime * 0.5f, 0);

                }
                if (transform.position.x >= -105 && transform.position.x <= -103)
                {
                    transform.Translate(-2 * Time.deltaTime, -1 * Time.deltaTime, 0);
                }
                else if (transform.position.x >= 103 && transform.position.x <= 100)
                {
                    transform.Translate(-2 * Time.deltaTime, 0.3f * Time.deltaTime, 0);
                }
                if (transform.position.x <= -78.9 && transform.position.x >= -84 && transform.position.y < 16)
                {
                    transform.Translate(-3 * Time.deltaTime, -0.45f * Time.deltaTime, 0);
                }
                if (transform.position.x <= -84 && transform.position.x > -94.4 && transform.position.y < 16)
                {
                    transform.Translate(-2 * Time.deltaTime, 0, 0);
                }
                if (level == 7 && transform.position.x <= -75 && transform.position.x >= -80)
                {
                    transform.Translate(-2 * Time.deltaTime, 0, 0);
                }
                if (level >= 9 && transform.position.y > -4.5)
                {
                    if (transform.position.x >= -80.5 && transform.position.x <= -65)
                    {
                        transform.Translate(-3 * Time.deltaTime, 0, 0);
                    }
                    else if (transform.position.x >= -65 && transform.position.x <= -60.5)
                    {
                        transform.Translate(-3 * Time.deltaTime, 0.6f * Time.deltaTime, 0);
                    }
                    else if (transform.position.x >= -60.5 && transform.position.x <= -59.8)
                    {
                        transform.Translate(-3 * Time.deltaTime, 2.5f * Time.deltaTime, 0);
                    }
                    else if (transform.position.x >= -59.8 && transform.position.x <= -59.5)
                    {
                        transform.Translate(-3 * Time.deltaTime, 4.2f * Time.deltaTime, 0);
                    }
                    else if (transform.position.x >= -59.5 && transform.position.x <= -56.5)
                    {
                        transform.Translate(-3 * Time.deltaTime, 1.1f * Time.deltaTime, 0);
                    }
                    else if (transform.position.x >= -56.5 && transform.position.x <= -53.1)
                    {
                        transform.Translate(-3 * Time.deltaTime, -0.8f * Time.deltaTime, 0);
                    }
                    else if (transform.position.x >= -53.1 && transform.position.x <= -52.2)
                    {

                        transform.Translate(-3 * Time.deltaTime, 0, 0);

                    }
                    else if (transform.position.x >= -52.2 && transform.position.x <= -49.1)
                    {
                        transform.Translate(-3 * Time.deltaTime, 0.9f * Time.deltaTime, 0);
                    }
                    else if (transform.position.x >= -49.1 && transform.position.x <= -44.4)
                    {
                        transform.Translate(-3 * Time.deltaTime, -0.16f * Time.deltaTime, 0);
                    }
                    else if (transform.position.x >= -44.4 && transform.position.x <= -43.4)
                    {

                        transform.Translate(-3 * Time.deltaTime, 0, 0);

                    }
                    else if (transform.position.x >= -43.4 && transform.position.x <= -41.4)
                    {
                        transform.Translate(-3 * Time.deltaTime, 0.4f * Time.deltaTime, 0);
                    }
                    else if (transform.position.x >= -41.4 && transform.position.x <= -38.4)
                    {
                        transform.Translate(-3 * Time.deltaTime, 0, 0);
                    }
                    else if (transform.position.x >= -38.4 && transform.position.x <= -37.1)
                    {
                        transform.Translate(-3 * Time.deltaTime, -0.5f * Time.deltaTime, 0);
                    }
                    else if (transform.position.x >= -37.1 && transform.position.x <= -36.1)
                    {
                        transform.Translate(-3 * Time.deltaTime, -3.63f * Time.deltaTime, 0);

                    }
                    else if (transform.position.x >= -36.1 && transform.position.x <= -32.9)
                    {
                        transform.Translate(-3 * Time.deltaTime, 0.3f * Time.deltaTime, 0);
                    }

                }
                if (level >= 9 && level < 14 && transform.position.y < -6.5)
                {
                    if (transform.position.x >= -36.1 && transform.position.x <= -26)
                    {
                        transform.Translate(-3 * Time.deltaTime, 0, 0);
                    }
                }
                if ((level == 14 || level == 15) && transform.position.y < -6.5)
                {
                    if (transform.position.x >= -36 && transform.position.x <= -24)
                    {
                        transform.Translate(-3 * Time.deltaTime, 0, 0);
                    }
                    else if (transform.position.x >= -24 && transform.position.x <= -12)
                    {
                        transform.Translate(-3 * Time.deltaTime, 0.625f * Time.deltaTime, 0);

                    }
                    else if (transform.position.x >= -12 && transform.position.x <= 0)
                    {
                        transform.Translate(-3 * Time.deltaTime, 0.425f * Time.deltaTime, 0);
                    }
                    else if (transform.position.x >= 0 && transform.position.x <= 7)
                    {
                        transform.Translate(-3 * Time.deltaTime, 0.643f * Time.deltaTime, 0);
                    }
                    else if (transform.position.x >= 7 && transform.position.x <= 15.1)
                    {
                        transform.Translate(-3 * Time.deltaTime, 0.9375f * Time.deltaTime, 0);
                    }
                }
                if (level == 17 && transform.position.x >= 26 && transform.position.x <= 32.1 && transform.position.y < -15)
                {
                    transform.Translate(-3 * Time.deltaTime, 0, 0);
                }
                if (level == 17 && transform.position.y > -6 && transform.position.x >= 30.7 && transform.position.x <= 58.7)
                {
                    transform.Translate(-4 * Time.deltaTime, -1 * Time.deltaTime, 0);
                }
            }
            else
            {

                transform.localScale = scale_ori;
                Controller.SetBool("move", false);
            }
        }









        //---------------动画状态转换部分--------------
        /*没胳膊没身子*/

        if (!Player.GetComponent<Slice_2>().SliceState)
        {

            if (Player.GetComponent<Slice_2>().BodySlice && Player.GetComponent<Slice_2>().ArmSlice)
            {
                Controller.SetBool("nobodyarm", true);

                leftfoot.SetActive(true);


                leftfoot.transform.position = transform.position + lf_off;

            }
            else
            {
                Controller.SetBool("nobodyarm", false);
                leftfoot.SetActive(false);
            }


            /*没条*/
            if (level >= 5)
            {
                if (Player.GetComponent<Slice_2>().ScrollSlice)
                {
                    Controller.SetBool("withscroll", false);
                }
                else
                {
                    Controller.SetBool("withscroll", true);
                }
            }

            /*没条没身子*/
            if (Player.GetComponent<Slice_2>().BodySlice && Player.GetComponent<Slice_2>().ScrollSlice)
            {
                Controller.SetBool("nobhat", true);
            }
            else
            {
                Controller.SetBool("nobhat", false);
            }
            //没身子,××××××××××××××××××用没条没身子代替
            if (Player.GetComponent<Slice_2>().BodySlice)
            {
                Controller.SetBool("nobhat", true);
            }
            else
            {
                Controller.SetBool("nobhat", false);
            }
            /*没胳膊*/
            if (Player.GetComponent<Slice_2>().ArmSlice)
            {
                Controller.SetBool("noarm", true);
            }
            else
            {
                Controller.SetBool("noarm", false);
            }

        }

        /*死亡*/
        
        if (isdead)
        {

            if (GetComponent<Slice_2>().BodySlice)
            {
                Body.SetActive(false);
            }
            if (GetComponent<Slice_2>().ArmSlice)
            {
                Arm.SetActive(false);
            }
            GetComponent<Slice_2>().BodySlice = false;
            GetComponent<Slice_2>().ArmSlice = false;

            GetComponent<Slice_2>().slicelock = true;
            Controller.SetTrigger("isdead");
            isdead = false;
            Debug.Log("复活！");



        }
        
        //瀑布停
        if (level < 4)
        {

            if (Player.GetComponent<Slice_2>().ArmSlice && Arm.GetComponent<ArmCheck>().check_arm_2)
            {
                if (!falllock)
                {
                    if (!Player.GetComponent<Slice_2>().SliceState)
                    {
                        waterfallconst.SetActive(false);
                        waterfall.SetActive(true);
                        falllock = true;
                        level = 3;
                    }

                }

            }
            else
            {
                falllock = false;
                waterfallconst.SetActive(true);
                waterfall.SetActive(false);

            }
            // 水面下降
            Body = GameObject.FindWithTag("body");
            if (!Player.GetComponent<Slice_2>().SliceState)
            {
                if (level == 3 && river.transform.position.y > -6.224508)
                {
                    GetComponent<Slice_2>().slicelock = true;
                    if (!fallreset)
                    {
                        transform.position = playerinfall;
                        fallreset = true;
                    }
                    river.transform.Translate(0, -1 * Time.deltaTime, 0);

                    rivermask.transform.Translate(0, -1 * Time.deltaTime, 0);


                    if (Body.transform.position.y > 12.04887)
                    {
                        Body.transform.Translate(-1f * Time.deltaTime, -1f * Time.deltaTime, 0, Space.World);
                    }
                    if (Player.transform.position.y > 13.14123)
                    {
                        Player.transform.Translate(-1f * Time.deltaTime, -1 * Time.deltaTime, 0);
                    }

                }

            }

        }
        if (level >= 4)
        {
            if (river.transform.position.y > -8)
            {
                river.transform.Translate(0, -1 * Time.deltaTime, 0);

                rivermask.transform.Translate(0, -1 * Time.deltaTime, 0);
            }

        }



        if (transform.position.x > -95 && transform.position.x < -92 && transform.position.y < 13.5 && transform.position.y > 13)
        {
            level = 4;
            GetComponent<Slice_2>().slicelock = false;
        }
        if (Player.GetComponent<Slice_2>().lv5reset && level < 5)
        {
            level = 5;
        }
        //---------------------------向下方向键------------------- 
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (level == 4 && transform.position.x > -93 && transform.position.x < -90)
            {
                scroll.SetActive(false);
                level = 5;
                Controller.SetBool("nobodyarm", false);
                Controller.SetBool("withscroll", true);
                //scroll.SetActive(false);

                if (Arm.activeInHierarchy)
                {
                    Arm.SetActive(false);
                }

                if (Body.activeInHierarchy)
                {
                    Body.SetActive(false);

                }



            }
            if (level == 6 && transform.position.x >= -79 && transform.position.x < -78.5)
            {
                character.SetActive(false);
                downmt.SetActive(true);

            }
            if (level >= 9 && transform.position.x >= -35.1 && transform.position.x <= -32.9 && transform.position.y >= -7 && transform.position.y <= -2.7)
            {
                transform.Translate(-0.7f * Time.deltaTime, -3 * Time.deltaTime, 0);
            }
            
            if (level == 17 && transform.position.x >= 30.5 && transform.position.x <= 31.5)
            {
                if (transform.position.y <= -5 && transform.position.y >= -16)
                    transform.Translate(0, -3 * Time.deltaTime, 0);
            }
        }
        if (level == 10)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (transform.position.x >= -33.7 && transform.position.x <= -33.2)
                {
                    Controller.SetTrigger("jump");
                }







            }
        }
        // -------------------------------向上方向键------------------------------------
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (level >= 9 && transform.position.x >= -35.2 && transform.position.x <= -33 && transform.position.y >= -7.1 && transform.position.y <= -2.7)
            {
                transform.Translate(0.7f * Time.deltaTime, 3 * Time.deltaTime, 0);
            }
            if (level == 17 && transform.position.x >= 30.5 && transform.position.x <= 31.5)
            {
                if (transform.position.y <= -5.5 && transform.position.y >= -16.2)
                    transform.Translate(0, 3 * Time.deltaTime, 0);
            }
        }
        // 搭梯子

        if (level == 5 && transform.position.x >= pos_xuanya.x)
        {
            scroll = GameObject.FindWithTag("scroll");
            if (scroll.GetComponent<ScrollCheck>().laddercheck)
            {
                level = 6;
                makeladder.SetActive(true);


            }

        }

        if (level == 7 && !Player.GetComponent<Slice_2>().ScrollSlice)
        {
            ladder.SetActive(false);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.x > -34.9 && transform.position.x < -34.4 && transform.position.y < -2.5)
            {
                transform.Translate(0, 1 * Time.deltaTime, 0);
            }
        }
        //搭秋千
        Body = GameObject.FindWithTag("body");
        scroll = GameObject.FindWithTag("scroll");
        if (level == 14 && Player.GetComponent<Slice_2>().BodySlice && Player.GetComponent<Slice_2>().ScrollSlice)
        {
            if (Body.GetComponent<BodyCheck>().check_qiuqian && scroll.GetComponent<ScrollCheck>().check_qiuqian)
            {
                level = 15;
                scroll.SetActive(false);

                qiuqian_anim.SetActive(true);
            }

        }
        if (level == 16)
        {
            qiuqian_anim.SetActive(true);

                
            if (!Player.GetComponent<Slice_2>().ScrollSlice && !Player.GetComponent<Slice_2>().BodySlice)
            {

                qiuqian_anim.SetActive(false);
                level = 17;
            }
        }
        if (level == 1 && boat.activeInHierarchy)
        {
            spark2.transform.position = boat.transform.position + spark2off;
        }

        if (level >= 1 && level <= 4 && transform.position.x >= -95.58405)
        {
            bigrockcamera.SetActive(true);
        }
        if (level == 7)
        {
            bigrockcamera.SetActive(false);



        }
        if (!Arm.GetComponent<ArmCheck>().check_arm_2 && level == 2)
        {
            if (!GetComponent<Slice_2>().SliceState)
            {
                if (!GetComponent<Slice_2>().BodySlice)
                {
                    isdead = true;
                }
                else if (Body.transform.position.y > 16.74 || Body.transform.position.y < 16.72)
                {
                    if (transform.position.y >= 16.48)
                    {
                        transform.Translate(0, -3 * Time.deltaTime, 0);
                    }
                    else
                    {
                        isdead = true;
                    }
                }
            }

        }

        if (level == 0 && !boat.activeInHierarchy && transform.position.x >= -114.8 && transform.position.x <= -105)
        {
            if (transform.position.y >= 16.48)
            {
                transform.Translate(0, -3 * Time.deltaTime, 0);
            }
            else
            {
                isdead = true;
            }

        }
        if (level == 1 && !boat.activeInHierarchy && transform.position.x >= -100)
        {
            if (transform.position.y >= 16.48)
            {
                transform.Translate(2 * Time.deltaTime, -3 * Time.deltaTime, 0);
            }
            else
            {
                isdead = true;
            }
        }
        if (transform.position.x >= 15 && level == 15 && transform.position.x < 20)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                qiuqian_anim.SetActive(false);
                Controller.SetTrigger("dang");
                
            }

        }
        if (level >= 15)
        {
            if (Controller.GetCurrentAnimatorStateInfo(0).IsName("dang"))
            {
                transform.position = pos_qiuqian;
            }
            else
            {
                

                if (level == 15 && transform.position.x >= 22.4)
                {
                    if (!lv16move)
                    {
                        transform.position = afterqiuqian;
                        lv16move = true;
                    }

                    qiuqian_anim.SetActive(true);
                    if (transform.position.x <= 26.7)
                    {
                        transform.Translate(2 * Time.deltaTime, -2 * Time.deltaTime, 0);
                    }
                    else
                    {
                        level = 16;
                    }
                }
            }
        }
        

        if (transform.position.x > 58 && transform.position.y > 1.4)
        {
            Application.LoadLevel("StartMenu");
        }
        if (level == 17 && !lv17acamera)
        {
            bigrockcamera.SetActive(true);
            lv17acamera = true;
            Player.layer = 12;
            character = Player.transform.Find("character").gameObject;
            character.layer = 12;

        }
    }
}
