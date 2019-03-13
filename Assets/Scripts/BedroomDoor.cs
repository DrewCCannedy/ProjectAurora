using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomDoor : MonoBehaviour
{

    GameObject player;

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
                gameObject.tag = "Door"; //Changes the object's tag to 'Door' which makes it interactable
        }
    }
}
