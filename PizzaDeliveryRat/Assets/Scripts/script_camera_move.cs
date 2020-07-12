using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_camera_move : MonoBehaviour
{
    public float forwardForce = 400;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 2);
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //GetComponent<Rigidbody>().AddForce(0, 0, forwardForce * Time.deltaTime);
        //transform.Translate(0,0,1 * Time.deltaTime);

        //transform.SetPositionAndRotation(new Vector3(0.0f,0.0f,transform.position.z), new Quaternion(0.0f, 0.0f, 0.0f, 1));
        //transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(7.0f, player.position.y+4, player.position.z+1);

    }
}
