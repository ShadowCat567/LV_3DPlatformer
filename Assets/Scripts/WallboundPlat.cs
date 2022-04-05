using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallboundPlat : MonoBehaviour
{
    //variables related to movement
    Rigidbody rb;
    float velo = 4.5f;
    Vector3 moveVect = new Vector3(1.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        //get the rigidbody
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //moves the object, in this case along the x-axis
        rb.velocity = moveVect * velo;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //when the platform runs into a wall, reverse direction
        if(collision.gameObject.tag == "Wall")
        {
            velo = -velo;
        }
    }
}
