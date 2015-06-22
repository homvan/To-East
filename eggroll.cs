using UnityEngine;
using System.Collections;

public class eggroll : MonoBehaviour {
    GameObject player,body,b0,b1,b2,b3,b4,b5;
    public int velocity;
    private float i0,i1,i2,i3,i4,i5;
    public bool dir,stopfluc;// 滚动方向,1右0左
    private Vector3 fluc_pos,scale,pos,velocity3_x,velocity3_y;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("player");
        b0 = GameObject.FindWithTag("b0");
        b1 = GameObject.FindWithTag("b1");
        b2 = GameObject.FindWithTag("b2");
        b3 = GameObject.FindWithTag("b3");
        b4 = GameObject.FindWithTag("b4");
        b5 = GameObject.FindWithTag("b5");
      
        i0 = 0;
        i1 = 0;
        i2 = 0;
        i3 = 0;
        i4 = 0;
        i5 = 0;
        dir = true;
        velocity = 1;
        fluc_pos.x = -70;
        fluc_pos.y = -2.810927f;
        fluc_pos.z = 0;
        velocity3_x.x = 1;
        velocity3_x.y = 0;
        velocity3_x.z = 0;
        velocity3_y.x = 0;
        velocity3_y.y = -1;
        velocity3_y.z = 0;
        stopfluc = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        body = GameObject.FindWithTag("body");
        //滚动
        if (player.GetComponent<RolerController2>().level == 7)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
     
            if (dir)
            {
                if (transform.position.x <= -70.3)
                {
                    GetComponent<Rigidbody2D>().gravityScale = 1;
                }
                else
                {
                    GetComponent<Rigidbody2D>().gravityScale = 0;
                }
                if (transform.position.y >= -2.1 &&transform.position.x > -71)
                {
                    dir = false;
                }
            }
            else
            {
                if (transform.position.x >= -72.54)
                {
                    GetComponent<Rigidbody2D>().gravityScale = 1;
                }
                else
                {
                    GetComponent<Rigidbody2D>().gravityScale = 0;
                }
                if (transform.position.y >= -2.1 && transform.position.x < -71)
                {
                    dir = true;
                }
            }

        }

      
        if (player.GetComponent<RolerController2>().level == 8 )
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        
          
            if (velocity >= 7)
            {
                
                player.GetComponent<RolerController2>().level = 9;
            }
            if (player.GetComponent<RolerController2>().level == 9)
            {
                
                pos.x = -70.80087f;
                pos.y = -3.056725f;
                pos.z = 0;
                transform.position = pos;
                scale.x = 0.5f;
                scale.y = 0.5f;
                scale.z = 1;
                body.transform.localScale = scale;
                pos.x = -72.06512f;
                pos.y = -2.489826f;
                pos.z = -11.13037f;
                body.transform.position = pos;
                
            }
           

                if (dir)
                {
                 
       
                    if (transform.position.x < -69.7 && transform.position.x >=-71.4)
                    {
                        scale.x = 0.5f;
                        scale.y = 0.5f;
                        scale.z = 1;
                        body.transform.localScale = scale;
                        pos.x = -72.06512f;
                        pos.y = -2.489826f;
                        pos.z = -11.13037f;
                        body.transform.position = pos;
                       
                    }
                    
                    if (transform.position.x >= -69.7)
                    {
                        dir = false;
                        GetComponent<Rigidbody2D>().velocity = velocity3_y * velocity*10;
                    }
                    //弹性！
                    if (transform.position.x < -71.4 && transform.position.x >= -71.5-0.02*velocity)
                    {
                     
                   

                        switch (velocity)
                        {
                            case 1:
                                //scale.x = 0.5f * 0.9f;
                                //scale.y = 0.5f / 0.9f;
                                //scale.z = 1;
                                //body.transform.localScale = scale;
                                //pos.x = -72.06512f;
                                //pos.y = -2.22f;
                                //pos.z = -11.13037f;
                                //body.transform.position = pos;
                                

                                break;
                            case 2:
                                
                                //    scale.x = 0.5f * (1 - 0.2f);
                                //    scale.y = 0.5f / (1 - 0.2f);
                                //    scale.z = 1;
                                //    body.transform.localScale = scale;
                                //    pos.x = -72.06512f;
                                //pos.y = -1.95f;
                                //pos.z = -11.13037f;
                                //body.transform.position = pos;
                                
                                break;
                            case 3:
                               
                                //    scale.x = 0.5f * (1 - 0.3f);
                                //    scale.y = 0.5f / (1 - 0.3f);
                                //    scale.z = 1;
                                //    body.transform.localScale = scale;
                                //    pos.x = -72.06512f;
                                //pos.y = -1.68f;
                                //pos.z = -11.13037f;
                                //body.transform.position = pos;
                                
                                break;
                            case 4:
                               
                                //    scale.x = 0.5f * (1 - 0.4f);
                                //    scale.y = 0.5f / (1 - 0.4f);
                                //    scale.z = 1;
                                //    body.transform.localScale = scale;
                                //  pos.x = -72.06512f;
                                //pos.y = -1.41f;
                                //pos.z = -11.13037f;
                                //body.transform.position = pos;
                                
                                break;
                            case 5:
                              
                                
                           //         scale.x = 0.5f * (1 - 0.5f);
                           //         scale.y = 0.5f / (1 - 0.5f);
                           //         scale.z = 1;
                           //         body.transform.localScale = scale;
                           //pos.x = -72.06512f;
                           //     pos.y = -1.14f;
                           //     pos.z = -11.13037f;
                           //     body.transform.position = pos;
                                
                                break;
                            case 6:
                               
                                //    scale.x = 0.5f * (1 - 0.6f);
                                //    scale.y = 0.5f / (1 - 0.6f);
                                //    scale.z = 1;
                                //    body.transform.localScale = scale;
                                //  pos.x = -72.06512f;
                                //pos.y = -0.87f;
                                //pos.z = -11.13037f;
                                //body.transform.position = pos;
                                break;
                            case 7:
                               
                                //    scale.x = 0.5f * (1 - 0.7f);
                                //    scale.y = 0.5f / (1 - 0.7f);
                                //    scale.z = 1;
                                //    body.transform.localScale = scale;
                                //    pos.x = -72.06512f;
                                //pos.y = -0.6f;
                                //pos.z = -11.13037f;
                                //body.transform.position = pos;
                                
                                break;
                            default:
                                break;
                        }
                     
                    }
                    

                }
                else
                {
                    
                    if (transform.position.x <= -71.4 -0.02 * velocity)
                    {
                  
                        dir = true;
                        velocity = velocity + 1;
                        GetComponent<Rigidbody2D>().velocity = velocity3_x * velocity*10;
                        if (velocity == 5)
                        {
                            GetComponent<Rigidbody2D>().velocity = velocity3_x * velocity * 20;
                        }
                    }
                    //弹性！
                    
                    if (transform.position.x > -71.4 - 0.02 * velocity && transform.position.x <= -71.4)
                    {
                     
                      
                        switch (velocity)
                        {
                            case 1:
                                //scale.x = 0.5f * 0.9f;
                                //scale.y = 0.5f / 0.9f;
                                //scale.z = 1;
                                //body.transform.localScale = scale;
                                //pos.x = -72.06512f;
                                //pos.y = -2.22f;
                                //pos.z = -11.13037f;
                                //body.transform.position = pos;


                                break;
                            case 2:

                                //scale.x = 0.5f * (1 - 0.2f);
                                //scale.y = 0.5f / (1 - 0.2f);
                                //scale.z = 1;
                                //body.transform.localScale = scale;
                                //pos.x = -72.06512f;
                                //pos.y = -1.95f;
                                //pos.z = -11.13037f;
                                //body.transform.position = pos;

                                break;
                            case 3:

                                //scale.x = 0.5f * (1 - 0.3f);
                                //scale.y = 0.5f / (1 - 0.3f);
                                //scale.z = 1;
                                //body.transform.localScale = scale;
                                //pos.x = -72.06512f;
                                //pos.y = -1.68f;
                                //pos.z = -11.13037f;
                                //body.transform.position = pos;

                                break;
                            case 4:

                                //scale.x = 0.5f * (1 - 0.4f);
                                //scale.y = 0.5f / (1 - 0.4f);
                                //scale.z = 1;
                                //body.transform.localScale = scale;
                                //pos.x = -72.06512f;
                                //pos.y = -1.41f;
                                //pos.z = -11.13037f;
                                //body.transform.position = pos;

                                break;
                            case 5:


                                //scale.x = 0.5f * (1 - 0.5f);
                                //scale.y = 0.5f / (1 - 0.5f);
                                //scale.z = 1;
                                //body.transform.localScale = scale;
                                //pos.x = -72.06512f;
                                //pos.y = -1.14f;
                                //pos.z = -11.13037f;
                                //body.transform.position = pos;

                                break;
                            case 6:

                                //scale.x = 0.5f * (1 - 0.6f);
                                //scale.y = 0.5f / (1 - 0.6f);
                                //scale.z = 1;
                                //body.transform.localScale = scale;
                                //pos.x = -72.06512f;
                                //pos.y = -0.87f;
                                //pos.z = -11.13037f;
                                //body.transform.position = pos;
                                break;
                            case 7:

                                //scale.x = 0.5f * (1 - 0.7f);
                                //scale.y = 0.5f / (1 - 0.7f);
                                //scale.z = 1;
                                //body.transform.localScale = scale;
                                //pos.x = -72.06512f;
                                //pos.y = -0.6f;
                                //pos.z = -11.13037f;
                                //body.transform.position = pos;

                             
                                break;
                            default:
                                break;
                        }
                    }
         
                }

            }
    
        if (player.GetComponent<RolerController2>().level >= 8 && velocity >= 2)
        {
            if (velocity >= 2 & i0 > -2.2)
            {
                b0.transform.Translate(-2 * Time.deltaTime, -0.9f * Time.deltaTime, 0, Space.World);
                i0 = i0 - Time.deltaTime;
            }
            if (velocity >= 3 & i1 > -2.2)
            {
                b1.transform.Translate(-2 * Time.deltaTime, -0.9f * Time.deltaTime, 0, Space.World);
                i1 = i1 - Time.deltaTime;
            }
            if (velocity >= 4 & i2 > -2.2)
            {
                b2.transform.Translate(-1.8f * Time.deltaTime, -0.9f * Time.deltaTime, 0, Space.World);
                i2 = i2 - Time.deltaTime;
            }
            if (velocity >= 5 & i3 > -2.2)
            {
                b3.transform.Translate(-1.7f * Time.deltaTime, -0.9f * Time.deltaTime, 0, Space.World);
                i3 = i3 - Time.deltaTime;
            }
            if (velocity >= 6 & i4 > -2.2)
            {
                b4.transform.Translate(-1.6f * Time.deltaTime, -0.9f * Time.deltaTime, 0, Space.World);
                i4 = i4 - Time.deltaTime;
            }
            if (velocity >= 7 & i5 > -2.2)
            {
                b5.transform.Translate(-1.5f * Time.deltaTime, -0.9f * Time.deltaTime, 0, Space.World);
                i5 = i5 - Time.deltaTime;
                if (!stopfluc)
                {
                    stopfluc = true;
                }
            }
        }
        if (player.GetComponent<RolerController2>().level == 9)
        {
            if (transform.position.x > -71.05 && transform.position.x < -70.95)
            {
                GetComponent<Rigidbody2D>().velocity = velocity3_x * 0;
            }
        }
         
	}
}
