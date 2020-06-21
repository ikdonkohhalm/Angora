using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammove : MonoBehaviour
{
    public float forwardForce = 400;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 2);

    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().AddForce(0, 0, forwardForce * Time.deltaTime);
        transform.Translate(0,0,1 * Time.deltaTime);

    }
}
