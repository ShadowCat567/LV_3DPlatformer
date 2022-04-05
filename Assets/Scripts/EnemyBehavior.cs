using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Rigidbody rb;
    float enemyVelo = 5.0f;
    public enum enemyType { x_dir, z_dir };
    public enemyType typeOfEnemy;
    Vector3 moveVect;

    Renderer rend;
    Color hitColor = new Color(0.86f, 0.02f, 0.02f);
    float hitTimer = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();

        switch(typeOfEnemy)
        {
            case enemyType.x_dir:
                moveVect = new Vector3(1.0f, 0.0f, 0.0f);
                break;
            case enemyType.z_dir:
                moveVect = new Vector3(0.0f, 0.0f, 1.0f);
                break;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVect * enemyVelo;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            enemyVelo = -enemyVelo;
        }

        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(changeColor(hitTimer));
        }
    }

    IEnumerator changeColor(float showColor)
    {
        rend.material.color = hitColor;
        yield return new WaitForSeconds(showColor);
        rend.material.color = Color.white;
    }
}
