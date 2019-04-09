using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interaction : MonoBehaviour
{

    public float sightDist;
    public SubtitleSystem subtitleSystem;
    RaycastHit objectHit;
    GameObject player;
    GameObject generator;
    GameObject cockpit;
    GameObject keypad;
    public GameObject flashlight;
    // door sound, written by drew
    public AudioClip doorOpen;
    public AudioClip doorReject;
    public AudioClip doorsmash1;
    public AudioClip doorsmash2;
    public AudioClip doorsmash3;

    public bool powerOn;
    bool powerOnTrigger = true;

    // keep track of wires 
    int wiresFound = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        generator = GameObject.FindWithTag("Power");
        cockpit = GameObject.FindWithTag("Cockpit");
        keypad = GameObject.FindWithTag("Keypad");
    }

    // Update is called once per frame
    void Update()
    {
        // play bridge subtitle when near bridge
        if (transform.position.x >= 24f && subtitleSystem.playBridgeOnce) {
           subtitleSystem.playBridgeOnce = false;
            subtitleSystem.playBridge = true;
        }

        // play green wire sounds
        if (wiresFound == 3) {
            subtitleSystem.playGreenWire = true;
            wiresFound++;
        }

        // play powerOn sound
        if (powerOn && powerOnTrigger) {
            subtitleSystem.playPowerOn = true;
            powerOnTrigger = false;
        }

        Debug.DrawRay(this.transform.position, this.transform.forward * sightDist, Color.magenta); //Checks for interactable objects by drawing a ray in front of the player
        if (Physics.Raycast(this.transform.position, this.transform.forward, out objectHit, sightDist))
        {
            if (objectHit.collider.gameObject.tag == ("Power") && Input.GetMouseButtonDown(0)) //Interaction with backup generator in bridge
            {
                Debug.Log("Interacted with " + objectHit.collider.gameObject.name + ".");
                player.GetComponent<Inventory>().inventoryMode = true;
            }

            if (objectHit.collider.gameObject.tag == ("Cockpit") && Input.GetMouseButtonDown(0)) //Interaction with cockpit terminal in bridge
            {
                Debug.Log("Interacted with " + objectHit.collider.gameObject.name + ".");
                player.GetComponent<Inventory>().inventoryMode = true;
                //cockpit.GetComponent<DataUpload>().PlugDrive();
            }

            if (objectHit.collider.gameObject.tag == ("Door") && Input.GetMouseButtonDown(0)) //Doors will either be moved or destroyed upon interaction
            {
                // created by drew
                // try and get door component
                BedroomDoor door = objectHit.collider.gameObject.GetComponent<BedroomDoor>();
                try {
                    // if player has flashlight and spacesuit
                    if (door.canOpen) {
                        // open door, run door animation
                        Debug.Log("Opened " + objectHit.collider.gameObject.name + ".");
                        if (powerOn) {
                            objectHit.collider.gameObject.GetComponent<Animator>().SetTrigger("open");
                            transform.parent.gameObject.GetComponent<AudioSource>().PlayOneShot(doorOpen);
                        } else {
                            if (door.timesHit < 3) {
                                objectHit.collider.gameObject.GetComponent<Animator>().SetTrigger("bash");
                                if (door.timesHit == 0) {
                                    transform.parent.gameObject.GetComponent<AudioSource>().PlayOneShot(doorsmash1);
                                } else if (door.timesHit == 1) {
                                    transform.parent.gameObject.GetComponent<AudioSource>().PlayOneShot(doorsmash2);
                                } else {
                                    transform.parent.gameObject.GetComponent<AudioSource>().PlayOneShot(doorsmash3);
                                }
                                door.timesHit++;
                            }
                        }
                        
                    } else {
                        transform.parent.gameObject.GetComponent<AudioSource>().PlayOneShot(doorReject);
                        subtitleSystem.playDoorHint = true;
                    }
                } catch (Exception e) { // this runs if there is no door script on the door. Just deletes the door
                    Destroy(objectHit.collider.gameObject);
                }
            }

                if (objectHit.collider.gameObject.tag == ("Keypad") && Input.GetMouseButtonDown(0)) //Occurs if escape pod keypad is interacted with
                {
                    Debug.Log("Interacted with keypad.");
                    keypad.GetComponent<PodCode>().keypadMode = true;

            }

                if (objectHit.collider.gameObject.tag == ("Pickup") && Input.GetMouseButtonDown(0)) //Pickups will be destroyed and placed into inventory upon interaction
            {
                //Debug.Log("Picked up " + objectHit.collider.gameObject.name + ".");

                if (objectHit.collider.gameObject.GetComponent<Pickups>().pickupID == Pickups.PickupList.spacesuit)
                {
                    Debug.Log("Picked up Spacesuit.");
                    player.GetComponent<Inventory>().hasSpacesuit = true;
                    
                    // play space suit AI audio
                    subtitleSystem.playSpaceSuit = true;

                    Destroy(objectHit.collider.gameObject);
                }

                if (objectHit.collider.gameObject.GetComponent<Pickups>().pickupID == Pickups.PickupList.flashlight)
                {
                    Debug.Log("Picked up Flashlight.");
                    player.GetComponent<Inventory>().hasFlashlight = true;
                    // created by drew
                    flashlight.SetActive(true);
                    // dont play flashlight AI audio
                    if (Time.time <= 18f) {
                        subtitleSystem.playFlashLight = false;
                    }

                    Destroy(objectHit.collider.gameObject);
                }

                if (objectHit.collider.gameObject.GetComponent<Pickups>().pickupID == Pickups.PickupList.rwire)
                {
                    Debug.Log("Picked up Red Wire.");
                    player.GetComponent<Inventory>().hasRwire = true;
                    wiresFound++;
                    Destroy(objectHit.collider.gameObject);
                    
                }

                if (objectHit.collider.gameObject.GetComponent<Pickups>().pickupID == Pickups.PickupList.gwire)
                {
                    Debug.Log("Picked up Green Wire.");
                    player.GetComponent<Inventory>().hasGwire = true;
                    Destroy(objectHit.collider.gameObject);
                }

                if (objectHit.collider.gameObject.GetComponent<Pickups>().pickupID == Pickups.PickupList.bwire)
                {
                    Debug.Log("Picked up Blue Wire.");
                    player.GetComponent<Inventory>().hasBwire = true;
                    wiresFound++;
                    Destroy(objectHit.collider.gameObject);
                }

                if (objectHit.collider.gameObject.GetComponent<Pickups>().pickupID == Pickups.PickupList.ywire)
                {
                    Debug.Log("Picked up Yellow Wire.");
                    player.GetComponent<Inventory>().hasYwire = true;
                    wiresFound++;
                    Destroy(objectHit.collider.gameObject);
                }

                if (objectHit.collider.gameObject.GetComponent<Pickups>().pickupID == Pickups.PickupList.rdrive)
                {
                    Debug.Log("Picked up Red Drive.");
                    player.GetComponent<Inventory>().hasRdrive = true;
                    Destroy(objectHit.collider.gameObject);
                }

                if (objectHit.collider.gameObject.GetComponent<Pickups>().pickupID == Pickups.PickupList.gdrive)
                {
                    Debug.Log("Picked up Green Drive.");
                    player.GetComponent<Inventory>().hasGdrive = true;
                    Destroy(objectHit.collider.gameObject);
                }

                if (objectHit.collider.gameObject.GetComponent<Pickups>().pickupID == Pickups.PickupList.bdrive)
                {
                    Debug.Log("Picked up Blue Drive.");
                    player.GetComponent<Inventory>().hasBdrive = true;
                    Destroy(objectHit.collider.gameObject);
                }

                if (objectHit.collider.gameObject.GetComponent<Pickups>().pickupID == Pickups.PickupList.ydrive)
                {
                    Debug.Log("Picked up Yellow Drive.");
                    player.GetComponent<Inventory>().hasYdrive = true;
                    Destroy(objectHit.collider.gameObject);
                }
            }
        }
    }
}
