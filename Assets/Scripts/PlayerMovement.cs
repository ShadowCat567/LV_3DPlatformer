using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;
    float velocity = 5.0f;
    float jumpVelo = 2000.0f;
    bool isJumping = false;
    Rigidbody rb;

    int curHealth;
    int maxHealth = 3;
    Renderer rend;
    Color dmgColor = new Color(0.98f, 0.0f, 0.31f);
    float dmgColorTimer = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        curHealth = maxHealth;
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVector = input.Get<Vector2>();

        moveVector = new Vector3(inputVector.x, 0, inputVector.y);
    }

    /*
    public void OnJump()
    {
        isJumping = true;
    }
    */

    private void FixedUpdate()
    {
        rb.velocity = moveVector * velocity;

        /*
        if(isJumping)
        {
            rb.AddForce(Vector3.up * jumpVelo);
            isJumping = false;
        }
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(colorFlash(dmgColorTimer));
            curHealth -= 1;
        }
    }

    IEnumerator colorFlash(float flashTime)
    {
        rend.material.color = dmgColor;
        yield return new WaitForSeconds(flashTime);
        rend.material.color = Color.white;
    }
}
