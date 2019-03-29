using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomDoor : MonoBehaviour
{

    GameObject player;
    public bool canOpen = false;
    public int timesHit = 0;
    public Interaction interaction;
    bool closedWhenPowerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.GetComponent<Inventory>().hasSpacesuit == true) && (player.GetComponent<Inventory>().hasFlashlight == true)) //Checks if Flashlight and Spacesuit are both in inventory
        {
                // changed by drew
                canOpen = true;
        }
        
        // play close door animation when power on
        if (!closedWhenPowerOn && interaction.powerOn) {
            GetComponent<Animator>().SetTrigger("powerOn");
            closedWhenPowerOn = true;
        }
    }
}
