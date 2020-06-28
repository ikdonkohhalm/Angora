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

    public script_ui_pizzatime linkToPizzaTimeScript;
    public script_ui_score linkToScoreScript;

    // Start is called before the first frame update
    void Start(){
        MainCollider = GetComponent<Collider>();
        AllColliders = GetComponentsInChildren<Collider>(true);
        rb = gameObject.GetComponent<Rigidbody>();
        DoRagdoll(false);
        ragdollTime = 0.0f;
        ragdollCooldown = 0.0f;
    }

    // Update is called once per frame
    void Update(){
        // Only allow movement if player is not ragdolling
        if(ragdollTime <= 0.0f){
           
            //Debug.Log("Stopped ragdoll");
            DoRagdoll(false);

            //translate based on key inputs. Move as long as key is pressed down
            if (Input.GetKey("a")){
                transform.Translate(-1 * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey("d")){
                transform.Translate(1 * Time.deltaTime, 0, 0);

            }
            if (Input.GetKeyDown("w")){
                //transform.Translate(0,jumpHeight * Time.deltaTime, 0);
                rb.velocity= new Vector3(0, 10*jumpHeight * Time.deltaTime, 0);
            }
            if (Input.GetKeyUp("space")){ // Pizza time
                pizzaTime();
               
            }

            // Move forward constantly
            transform.Translate(0, 0, 1*Time.deltaTime);
        }
        // Decrement ragdoll timers by 0.1 each frame
        ragdollTime -= 0.1f;
        ragdollCooldown -= 0.1f;

        if(this.transform.position.y < 1){
            this.transform.position = new Vector3(this.transform.position.x, 1.5f, this.transform.position.z);
            //this.transform.Translate(new Vector3(0,1,0));
        }
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
            ragdollCooldown = 500.0f;
        }
        
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Obstacle" && ragdollCooldown <= 0.0f){
            Debug.Log("Entering Ragdoll");
            DoRagdoll(true);
        }
    }
    
    void pizzaTime(){
        totalScore += pizzaPoints * linkToPizzaTimeScript.toggle();
        Debug.Log("Score = " + totalScore);
        linkToScoreScript.update(totalScore);
    }
}
