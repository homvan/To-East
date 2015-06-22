using UnityEngine;
using System.Collections;

public class ScrollCheck : MonoBehaviour {
    GameObject player;
    public bool laddercheck,check_qiuqian;
    private Vector3 ladder_pos,qiuqian_pos;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("player");
        ladder_pos.x = -78.10989f;
        ladder_pos.y = 13.13621f;
        ladder_pos.z = 0;
        qiuqian_pos.x = 20f;
        qiuqian_pos.y = -10.16282f;
        qiuqian_pos.z = 0;
        check_qiuqian = false;
        laddercheck = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (player.GetComponent<RolerController2>().level == 5)
        {
            if (transform.position.x > -80 && transform.position.x < -76 && transform.position.y < 15 && transform.position.y > 11)
            {
                Debug.Log(transform.position);
               
                transform.position = ladder_pos;
                laddercheck = true;
           
            }
           
         }
        if (player.GetComponent<RolerController2>().level == 14)
        {
            if (transform.position.x > 19 && transform.position.x < 21 && transform.position.y > -11 && transform.position.y < -9)
            {
                transform.position = qiuqian_pos;
                check_qiuqian = true;
            }
        }
        
        
        
	}
}
