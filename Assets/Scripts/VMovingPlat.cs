using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VMovingPlat : MonoBehaviour
{
    Rigidbody rb;
    float moveVelo = 8.0f;
    Vector3 moveVect;
    bool stopMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVelo * moveVect;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stop")
        {
            stopMoving = true;
            transform.position = other.gameObject.transform.position;
            moveVect = new Vector3(0.0f, 0.0f, 0.0f);
            rb.isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && !stopMoving)
        {
            moveVect = new Vector3(0.0f, 1.0f, 0.0f);
        }
    }
}
