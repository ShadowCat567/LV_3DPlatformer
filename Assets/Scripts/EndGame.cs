using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGame : MonoBehaviour
{
    //sets the objects the object that ends the game needs to know about
    [SerializeField] TMP_Text endText;
    [SerializeField] GameObject endpanel;
    [SerializeField] GameObject endButton;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //deactivates everything that is shown at the end of the game
        endText.text = "";
        endpanel.SetActive(false);
        endButton.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //when the player collides with the end game object, show the end of game screen.
        if(collision.gameObject.tag == "Player")
        {
            //get the score from the player to display
            endText.text = "You scored " + player.GetComponent<PlayerMovement>().score + " points!";
            endpanel.SetActive(true);
            endButton.SetActive(true);
        }
    }
}
