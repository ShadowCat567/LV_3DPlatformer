using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallboundPlat : MonoBehaviour
{
    Rigidbody rb;
    float velo = 4.5f;
    Vector3 moveVect = new Vector3(1.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVect * velo;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            velo = -velo;
        }
    }
}
