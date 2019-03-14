using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    GameObject player;
    int wiresPlugged = 0;
    public bool powerOn;
    public GameObject redWire;
    public GameObject greenWire;
    public GameObject blueWire;
    public GameObject yellowWire;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (wiresPlugged == 4)
        {
            powerOn = true;
            //Debug.Log("Ship power online.");
        }

    }

    public void PlugWires()
    {
        if ((player.GetComponent<Inventory>().hasRwire == true) && (Input.GetMouseButtonDown(0)))
        {
            Instantiate(redWire, new Vector3(32.77f, -0.24f, 11.67f), Quaternion.Euler(new Vector3(90, 0, -90)));
            wiresPlugged = wiresPlugged + 1;
            Debug.Log("wiresPlugged = " + wiresPlugged);
            player.GetComponent<Inventory>().hasRwire = false;
        }

        else if ((player.GetComponent<Inventory>().hasGwire == true) && (Input.GetMouseButtonDown(0)))
        {
            Instantiate(greenWire, new Vector3(32.9f, -0.15f, 11.75f), Quaternion.Euler(new Vector3(90, -180, 90)));
            wiresPlugged = wiresPlugged + 1;
            Debug.Log("wiresPlugged = " + wiresPlugged);
            player.GetComponent<Inventory>().hasGwire = false;
        }

        else if ((player.GetComponent<Inventory>().hasBwire == true) && (Input.GetMouseButtonDown(0)))
        {
            Instantiate(blueWire, new Vector3(32.6f, -0.3f, 11.6f), Quaternion.Euler(new Vector3(90, 180, 90)));
            wiresPlugged = wiresPlugged + 1;
            Debug.Log("wiresPlugged = " + wiresPlugged);
            player.GetComponent<Inventory>().hasBwire = false;
        }

        else if ((player.GetComponent<Inventory>().hasYwire == true) && (Input.GetMouseButtonDown(0)))
        {
            Instantiate(yellowWire, new Vector3(32.9f, -0.4f, 11.7f), Quaternion.Euler(new Vector3(90, -180, -90)));
            wiresPlugged = wiresPlugged + 1;
            Debug.Log("wiresPlugged = " + wiresPlugged);
            player.GetComponent<Inventory>().hasYwire = false;
        }
    }
}
