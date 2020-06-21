using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpHeight=15;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 1*Time.deltaTime);

        //translate based on key inputs. Move as long as key is pressed down
        if (Input.GetKey("a"))
        {
            transform.Translate(-1 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(1 * Time.deltaTime, 0, 0);

        }
        if (Input.GetKeyDown("w"))
        {
            //transform.Translate(0,jumpHeight * Time.deltaTime, 0);
            rb.velocity= new Vector3(0, 10*jumpHeight * Time.deltaTime, 0);
        }
    }
}
