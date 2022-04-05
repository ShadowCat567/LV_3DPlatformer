using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMovingPlat : MonoBehaviour
{
    //movement related variables
    Rigidbody rb;
    float moveVelo = 4.0f;
    Vector3 moveVect = new Vector3(0.0f, 0.0f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        //get access to rigidbody
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //move the platform (along the z axis)
        rb.velocity = moveVect * moveVelo;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            //if the platform runs into an object tagged with "Ground", reverse direction
            moveVelo = -moveVelo;
        }
    }
}
