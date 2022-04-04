using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 playerOffset;

    // Start is called before the first frame update
    void Start()
    {
        playerOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            transform.position = Vector3.Lerp(transform.position, player.position + playerOffset, 0.2f);
        }
    }
}
