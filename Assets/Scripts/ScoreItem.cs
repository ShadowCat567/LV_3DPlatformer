using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    MeshRenderer mr;
    SphereCollider sc;

    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<SphereCollider>();
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            sc.enabled = false;
            mr.enabled = false;
        }
    }
}
