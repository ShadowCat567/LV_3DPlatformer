using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMovingPlat : MonoBehaviour
{
    Rigidbody rb;
    float moveVelo = 4.0f;
    Vector3 moveVect = new Vector3(0.0f, 0.0f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVect * moveVelo;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            moveVelo = -moveVelo;
        }
    }
}
