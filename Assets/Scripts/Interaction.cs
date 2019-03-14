using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public float sightDist;
    public SubtitleSystem subtitleSystem;
    RaycastHit objectHit;
    GameObject player;
    GameObject generator;
    GameObject cockpit;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        generator = GameObject.FindWithTag("Power");
        cockpit = GameObject.FindWithTag("Cockpit");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * sightDist, Color.magenta); //Checks for interactable objects by drawing a ray in front of the player
        if (Physics.Raycast(this.transform.position, this.transform.forward, out objectHit, sightDist))
        {
            if (objectHit.collider.gameObject.tag == ("Power") && Input.GetMouseButtonDown(0)) //Interaction with backup generator in bridge
            {
                Debug.Log("Interacted with " + objectHit.collider.gameObject.name + ".");
                player.GetComponent<Inventory>().inventoryMode = true;
                //generator.GetComponent<Generator>().PlugWires();
            }

            if (objectHit.collider.gameObject.tag == ("Cockpit") && Input.GetMouseButtonDown(0)) //Interaction with cockpit terminal in bridge
            {
                Debug.Log("Interacted with " + objectHit.collider.gameObject.name + ".");
                cockpit.GetComponent<DataUpload>().PlugDrive();
            }

            if (objectHit.collider.gameObject.tag == ("Door") && Input.GetMouseButtonDown(0)) //Doors will either be moved or destroyed upon interaction
            {
                Debug.Log("Opened " + objectHit.collider.gameObject.name + ".");
                Destroy(objectHit.collider.gameObject);
            }

            if (objectHit.collider.gameObject.tag == ("Pickup") && Input.GetMouseButtonDown(0)) //Pickups will be destroyed and placed into inventory upon interaction
            {
                //Debug.Log("Picked up " + objectHit.collider.gameObject.name + ".");

                if (objectHit.collider.gameObject.GetComponent<Pickups>().pickupID == Pickups.PickupList.spacesuit)
                {
                    Debug.Log("Picked up Spacesuit.");
                    player.GetComponent<Inventory>().hasSpacesuit = true;
                    
                    // play space suit AI subtitles
                    subtitleSystem.SetPlaySpaceSuit(true);

                    Destroy(objectHit.collider.gameObject);
                }

                if (objectHit.collider.gameObject.GetComponent<Pickups>().pickupID == Pickups.PickupList.flashlight)
                {
                    Debug.Log("Picked up Flashlight.");
                    player.GetComponent<Inventory>().hasFlashlight = true;
                    Destroy(objectHit.collider.gameObject);
                }

                if (objectHit.collider.gameObject.GetComponent<Pickups>().pickupID == Pickups.PickupList.rwire)
                {
                    Debug.Log("Picked up Red Wire.");
                    player.GetComponent<Inventory>().hasRwire = true;
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
                    Destroy(objectHit.collider.gameObject);
                }

                if (objectHit.collider.gameObject.GetComponent<Pickups>().pickupID == Pickups.PickupList.ywire)
                {
                    Debug.Log("Picked up Yellow Wire.");
                    player.GetComponent<Inventory>().hasYwire = true;
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
