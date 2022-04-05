using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VMovingPlat : MonoBehaviour
{
    Rigidbody rb;
    float moveVelo = 8.0f;
    Vector3 moveVect;
    bool stopMoving = false;
    Renderer rend;
    Color stillColor = new Color(0.27f, 0.39f, 0.17f);
    Color movingColor = new Color(0.08f, 0.56f, 0.47f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
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
            rend.material.color = stillColor;
            rb.isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && !stopMoving)
        {
            moveVect = new Vector3(0.0f, 1.0f, 0.0f);
            rend.material.color = movingColor;
        }
    }
}
