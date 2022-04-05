using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGame : MonoBehaviour
{
    [SerializeField] TMP_Text endText;
    [SerializeField] GameObject endpanel;
    [SerializeField] GameObject endButton;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        endText.text = "";
        endpanel.SetActive(false);
        endButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            endText.text = "You scored " + player.GetComponent<PlayerMovement>().score + " points!";
            endpanel.SetActive(true);
            endButton.SetActive(true);
        }
    }
}
