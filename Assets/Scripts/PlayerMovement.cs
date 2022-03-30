using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector3 moveVector;
    float velocity = 5.0f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVector = input.Get<Vector2>();

        moveVector = new Vector3(inputVector.x, 0, inputVector.y);
    }

    public void OnJump()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * velocity;
    }
}
