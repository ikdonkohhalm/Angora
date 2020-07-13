using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_player_move : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpHeight=15;
    public Collider MainCollider;
    public Collider[] AllColliders;
    public float ragdollTime;
    public float ragdollCooldown;
    float totalScore;
    float pizzaPoints = 1;
    public float speed = 2;
    public bool finished = false;

    public script_ui_pizzatime linkToPizzaTimeScript;
    public script_ui_score linkToScoreScript;
    public script_ui_score linkToFinalScoreScript;
    public script_ui_mainmenu linkToMenuScript;


    // Start is called before the first frame update
    void Start(){
        //void Awake() { 
        Debug.Log("start move");
        MainCollider = GetComponent<Collider>();
        AllColliders = GetComponentsInChildren<Collider>(true);
        rb = gameObject.GetComponent<Rigidbody>();
        DoRagdoll(false);
        ragdollTime = 0.0f;
        ragdollCooldown = 0.0f;
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update(){
        // Only allow movement if player is not ragdolling
        if(ragdollTime <= 0.0f){
           
            //Debug.Log("Stopped ragdoll");
            DoRagdoll(false);

            //translate based on key inputs. Move as long as key is pressed down
            if (Input.GetKey("a")){
                transform.Translate(-1* speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey("d")){
                transform.Translate(speed * Time.deltaTime, 0, 0);

            }
            if (Input.GetKeyDown("w")){
                //transform.Translate(0,jumpHeight * Time.deltaTime, 0);
                //rb.velocity= new Vector3(0, 10*jumpHeight * Time.deltaTime, 0);
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }
            if (Input.GetKeyUp("space")){ // Pizza time
                pizzaTime();
               
            }

            // Move forward constantly
            transform.Translate(0, 0, speed*Time.deltaTime);
        }
        // Decrement ragdoll timers by 0.1 each frame
        ragdollTime -= 0.1f;
        ragdollCooldown -= 0.1f;
    }

    // <summary>
    // Enters or exits ragdoll mode.
    // <param name="isRagdoll"> True if entering ragdoll mode, false if exiting ragdoll mode
    // </summary>
    public void DoRagdoll(bool isRagdoll){
        // Enable each collider if we're in ragdoll mode.
        foreach(var col in AllColliders)
            col.enabled = isRagdoll;
        MainCollider.enabled = !isRagdoll;
        rb.useGravity = !isRagdoll;
        GetComponent<Animator>().enabled = !isRagdoll;

        if(isRagdoll && ragdollTime <= 0.0f){
            //Debug.Log("Started ragdoll");
            ragdollTime = 100.0f;
            ragdollCooldown = 200.0f;
        }
        
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Obstacle" && ragdollCooldown <= 0.0f){
            DoRagdoll(true);
        }
        if(collision.gameObject.tag == "Finish" & !finished){
            //calculate score based on time
            float finishScore = 30- Time.time;
            if (finishScore < 0){
                finishScore = 0;
            }
            totalScore += finishScore;
            Debug.Log("Score = " + totalScore);
            linkToFinalScoreScript.update(totalScore);

            speed = 0;
            linkToMenuScript.isFinished =true;
            //Time.timeScale = 0;
            finished = true;
        }
    }
    
    void pizzaTime(){
        totalScore += pizzaPoints * linkToPizzaTimeScript.toggle();
        Debug.Log("Score = " + totalScore);
        linkToScoreScript.update(totalScore);
    }
}
