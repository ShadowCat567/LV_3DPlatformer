using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //gets the player and sets a vector3 for the camera's offset from the player
    [SerializeField] Transform player;
    Vector3 playerOffset;

    // Start is called before the first frame update
    void Start()
    {
        //sets the camera's offset from the player
        playerOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if there is a player, follow it using Lerp
        if(player)
        {
            transform.position = Vector3.Lerp(transform.position, player.position + playerOffset, 0.2f);
        }
    }
}
