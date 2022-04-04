using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;
    float velocity = 5.0f;
    bool isJumping = false;
    bool grounded = true;
    Rigidbody rb;

    int curHealth;
    int maxHealth = 3;
    Renderer rend;
    Color dmgColor = new Color(0.98f, 0.0f, 0.31f);
    float dmgColorTimer = 0.3f;
    [SerializeField] Transform respawnPos;
    [SerializeField] Image[] healthArr = new Image[3];

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        curHealth = maxHealth;
    }

    private void Update()
    {
        if(curHealth == 0)
        {
            transform.position = respawnPos.position;
            curHealth = maxHealth;
            ResetHearts();
        }
    }

    void ResetHearts()
    {
        for(int i = 0; i < healthArr.Length; i ++)
        {
            healthArr[i].enabled = true;
        }
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVector = input.Get<Vector2>();

        moveVector = new Vector3(inputVector.x, 0, inputVector.y);
    }

    public void OnJump()
    {
        isJumping = true;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * velocity;

        if (grounded)
        {
            if (isJumping)
            {
                rb.AddForce(new Vector3(0, 100, 0), ForceMode.Impulse);
                isJumping = false;
                grounded = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(colorFlash(dmgColorTimer));
            curHealth -= 1;
            healthArr[curHealth].enabled = false;
        }

        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    IEnumerator colorFlash(float flashTime)
    {
        rend.material.color = dmgColor;
        yield return new WaitForSeconds(flashTime);
        rend.material.color = Color.white;
    }
}
