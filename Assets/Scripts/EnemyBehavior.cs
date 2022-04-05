using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //movement related variables
    Rigidbody rb;
    float enemyVelo = 5.0f;
    Vector3 moveVect;

    //color related variables
    Renderer rend;
    Color hitColor = new Color(0.86f, 0.02f, 0.02f);
    Color originalColor = new Color(0.33f, 0.03f, 0.03f);
    float hitTimer = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        //sets the the move direction, gets access to renderer and rigidbody
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        moveVect = new Vector3(1.0f, 0.0f, 0.0f);
    }

    private void FixedUpdate()
    {
        //moves the enemy along the x axis
        rb.velocity = moveVect * enemyVelo;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            //if the enemy runs into another enemy or the wall, reverse direction
            enemyVelo = -enemyVelo;
        }

        if(collision.gameObject.tag == "Player")
        {
            //if the enemy runs into the player, change color for a fraction of a second
            StartCoroutine(changeColor(hitTimer));
        }
    }

    IEnumerator changeColor(float showColor)
    {
        //change color to hitColor to a fraction of a second, then change back to normal color
        rend.material.color = hitColor;
        yield return new WaitForSeconds(showColor);
        rend.material.color = originalColor;
    }
}
