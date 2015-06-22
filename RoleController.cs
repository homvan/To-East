using UnityEngine;
using System.Collections;

public class RoleController : MonoBehaviour {
	public Animator Controller;
	private GameObject role,rock,stepjump,rocktrigger,arm,body,wood,bigbranch,littlebranch,hat;
	private bool arm_sliced,body_sliced,rstate,isfull,withhat,hatfallen,isdead=false;
    private float speed = 1.0f;
	public bool rockfall;
	public int state;
    private bool check;
    private Vector3 speed3,postmp;
    private AnimatorStateInfo stateInfo;
	//state, 0:begin,1:afgerrock,2:afterwood,3:afterbranch,4:gethat;


	// Use this for initialization
	void Start () {
        
		role = GameObject.FindWithTag ("player");
		rock = GameObject.FindWithTag ("rock");
        rocktrigger = GameObject.FindWithTag("rocktrigger");
        stepjump = GameObject.FindWithTag("stepjump");
        stepjump.SetActive(false);
        rocktrigger.SetActive(false);
        rock.SetActive(false);
        wood = GameObject.FindWithTag("wood");
        bigbranch = GameObject.FindWithTag("bigbranch");
        wood.SetActive(false);
        bigbranch.SetActive(false);
        littlebranch = GameObject.FindWithTag("branchanim");
        littlebranch.SetActive(false);
        hat = GameObject.FindWithTag("hat");
        
	}
	
	// Update is called once per frame
    void Update()
    {
        stateInfo = Controller.GetCurrentAnimatorStateInfo(0);

        arm_sliced = role.GetComponent<Slice>().ArmSlice;
        /*if (arm_sliced)
        {
            Controller.SetBool("arm_sliced", true);
        }
        else
        {
            Controller.SetBool("arm_sliced", false);
        }*/
        
        body_sliced = role.GetComponent<Slice>().BodySlice;
        if (body_sliced)
        {
            Controller.SetBool("body_sliced", true);
            body = GameObject.FindWithTag("body");
        }
        else
        {
            Controller.SetBool("body_sliced", false);
        }
        if (arm_sliced || body_sliced)
        {
            isfull = false;
        }
        else
        {
            isfull = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Controller.SetBool("move", true);
            if (transform.position.x <= -71.29495f)
            {
                transform.Translate(speed * Time.deltaTime, 0f, 0f);
            }

            if (transform.position.x >= -69f && transform.position.x < -63.58213f && rockfall)
            {
                transform.Translate(speed * Time.deltaTime, 0f, 0f);
            }
            if (transform.position.x >= -63.6 && transform.position.x <= -60.8)
            {
                speed3.x = -(-63.5f - (-60.8f));
                speed3.y = -(-2.8f - (-1.337879f));
                speed3.z = 0f;
                speed3 = speed3 / 3;
                transform.Translate(speed3 * Time.deltaTime);
            }
            //-------------------------------------------wood----------------------------------------------
            if (body_sliced && body.transform.position.x < -39.9f && body.transform.position.x > -40.1f && body.transform.position.y < 0 && body.transform.position.y > -0.2)
            {

                check = true;
            }
            else
            {
                check = false;
            }
            if (transform.position.x < -60.79f && transform.position.x > -60.81f && (!check))
            {
                wood.SetActive(true);
                bigbranch.SetActive(true);
                Controller.SetTrigger("woodfall");
                stateInfo = Controller.GetCurrentAnimatorStateInfo(0);
                isdead = true;

                
                //dead
            }
            else
            {
                state = 2;

            }
            if (transform.position.x < -60f)
            {
                transform.Translate(speed3 * Time.deltaTime);
            }
            if (transform.position.x >= -60 && transform.position.x < -57.9f && state == 2)
            {
                speed3.x = -(-60f - (-57.90286f));
                speed3.y = -(-1f - (-2.030902f));
                speed3.z = 0f;
                speed3 = speed3 / 3;
                transform.Translate(speed3 * Time.deltaTime);
            }
            if (transform.position.x >= -57.9f && transform.position.y < -5.3f)
            {
                transform.Translate(speed * Time.deltaTime, 0f, 0f);
            }
        }
        else
        {
            Controller.SetBool("move", false);
        }

        if (transform.position.x < -71.29f && transform.position.x > -71.30f && Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("jump true");
            stepjump.SetActive(true);


        }
        if ((transform.position.x < -68f && transform.position.x > -69f) && arm_sliced && (!rockfall) && Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("rockn'roll!");
            rocktrigger.SetActive(true);
            rockfall = true;
            state = 1;


        }
        if (arm_sliced && (!body_sliced) && transform.position.x <= -57f && transform.position.x >= -59.0 && Input.GetKey(KeyCode.DownArrow))
        {
            Controller.SetTrigger("noarmjump");
            Debug.Log("noarmjump");
            hatfallen = true;
            state = 3;

        }
        if (isfull && transform.position.x <= -57.8f && transform.position.x >= -58.0 && Input.GetKey(KeyCode.DownArrow))
        {
            Controller.SetTrigger("treehole");
            postmp.x = -58f;
            postmp.y = -5.5f;
            postmp.z = 0f;
            transform.position = postmp;
        }
        if (transform.position.x < -44f && transform.position.x > -49f && hatfallen && (!withhat) && Input.GetKey(KeyCode.DownArrow))
        {
            withhat = true;
            Controller.SetTrigger("withhat");
            hat.SetActive(false);
            state = 4;
        }

        if (transform.position.x < -41 && transform.position.x > -43 && !(withhat))
        {
            Controller.SetTrigger("dead");
            isdead = true;
            
        }
       /* if (isdead && stateInfo.nameHash == Animator.StringToHash("Base Layer.CharStay"))
        {
            if (state == 1){
                postmp.x = -63.6f;
                postmp.y = -2.686184f;
                postmp.z = 0f;
                transform.position = postmp;
            }
            if (state !=4) {
                postmp.x = -50f;
                postmp.y = -5.5f;
                postmp.z = 0f;
                transform.position = postmp;
            }
        }
        */
        if (transform.position.x >= -35)
        {
            Application.LoadLevel("Scene2");
        }
    }

	
}
