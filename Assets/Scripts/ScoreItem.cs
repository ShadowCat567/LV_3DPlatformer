using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    //sets up variables for the score object to use
    MeshRenderer mr;
    SphereCollider sc;

    // Start is called before the first frame update
    void Start()
    {
        //gives score object access to its renderer and collider
        sc = GetComponent<SphereCollider>();
        mr = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if the player runs into it, deactivate the score object so it is uncollideable and invisible
        if(collision.gameObject.tag == "Player")
        {
            sc.enabled = false;
            mr.enabled = false;
        }
    }
}
