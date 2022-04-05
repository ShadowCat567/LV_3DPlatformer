using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    //movement and jumping related variables
    Vector3 moveVector = Vector3.zero;
    float velocity = 5.0f;
    bool isJumping = false;
    bool grounded = true;
    Rigidbody rb;
    PlayerInput pi;

    //variables related to health and color
    int curHealth;
    int maxHealth = 3;
    Renderer rend;
    Color dmgColor = new Color(0.98f, 0.0f, 0.31f);
    float dmgColorTimer = 0.3f;
    [SerializeField] Transform respawnPos;
    [SerializeField] Image[] healthArr = new Image[3];

    //variables related to score
    public int score = 0;
    [SerializeField] TMP_Text score_text;
    Color scoreColor = new Color(0.8f, 0.57f, 0.07f);

    // Start is called before the first frame update
    void Start()
    {
        //gets access to rigidbody, renderer, and playerInput, sets curHealth, and sets up score text
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        pi = GetComponent<PlayerInput>();
        curHealth = maxHealth;
        score_text.text = "Score: " + score;
    }

    private void Update()
    {
        if(curHealth <= 0)
        {
            //if the player is dead, respawn them as starting position and reset their health and lives
            transform.position = respawnPos.position;
            curHealth = maxHealth;
            ResetHearts();
        }
    }

    void ResetHearts()
    {
        //reset the images that display health
        for(int i = 0; i < healthArr.Length; i ++)
        {
            healthArr[i].enabled = true;
        }
    }

    public void OnMove(InputValue input)
    {
        //set an inputVector based on player input
        Vector2 inputVector = input.Get<Vector2>();

        //set the player's moveVector based on information from the input vector
        moveVector = new Vector3(inputVector.x, 0, inputVector.y);
    }

    public void OnJump()
    {
        //if the player hits the jump key, set isJumping to true
        isJumping = true;
    }

    private void FixedUpdate()
    {
        //moves the player
        rb.velocity = moveVector * velocity;

        if (grounded)
        {
            if (isJumping)
            {
                //so long as the player is grounded, jump when jump key is pressed
                //I don't really like how this jump feels in game, but I couldn't find anything better
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
            //if the player runs into an enemy, change their color for a fraction of a second and update the corresponding health related variables to diplay 1 less hit point
            StartCoroutine(colorFlash(dmgColorTimer, dmgColor));
            curHealth -= 1;
            healthArr[curHealth].enabled = false;
        }

        if(collision.gameObject.tag == "Ground")
        {
            //if the player is colliding with the ground, they are grounded
            grounded = true;
        }

        if(collision.gameObject.tag == "Score")
        {
            //if the player collides with a score object, increase score and change color for a fraction of a second
            StartCoroutine(colorFlash(dmgColorTimer, scoreColor));
            score += 1;
            score_text.text = "Score: " + score;
        }

        if(collision.gameObject.tag == "Death")
        {
            //if the player falls off the map, kill them
            curHealth = 0;
        }

        if(collision.gameObject.tag == "Finish")
        {
            //if the player runs into the end object, turn off playerInput
            pi.enabled = false;
        }
    }

    IEnumerator colorFlash(float flashTime, Color flashedColor)
    {
        //change the player's color for a designated amount of time
        rend.material.color = flashedColor;
        yield return new WaitForSeconds(flashTime);
        rend.material.color = Color.white;
    }
}
