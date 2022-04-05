using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VMovingPlat : MonoBehaviour
{
    //varaibles related to movements
    Rigidbody rb;
    float moveVelo = 8.0f;
    Vector3 moveVect;
    bool stopMoving = false;

    //variables related to color
    Renderer rend;
    Color stillColor = new Color(0.27f, 0.39f, 0.17f);
    Color movingColor = new Color(0.08f, 0.56f, 0.47f);

    // Start is called before the first frame update
    void Start()
    {
        //get access to renderer and rigidbody
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        //move the platform (in this case along the y-axis
        rb.velocity = moveVelo * moveVect;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stop")
        {
            //when the platform runs into the stop object, make it stop moving and stop obeying normal physics so it stays in place
            //change its color base to its base color
            stopMoving = true;
            transform.position = other.gameObject.transform.position;
            moveVect = new Vector3(0.0f, 0.0f, 0.0f);
            rend.material.color = stillColor;
            rb.isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && !stopMoving)
        {
            //if the player collides with this platform, make it move upwards and change its color
            moveVect = new Vector3(0.0f, 1.0f, 0.0f);
            rend.material.color = movingColor;
        }
    }
}
