using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpHeight=15;
    public Collider MainCollider;
    public Collider[] AllColliders;
    public float ragdollTime;
    public float ragdollCooldown;

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
            transform.Translate(0, 0, 1*Time.deltaTime);
            }
            ragdollTime -= 0.1f;
            ragdollCooldown -= 0.1f;
    }

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

    }
}
