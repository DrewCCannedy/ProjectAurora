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

    private float redPosX = 32.903f, redPosY = -0.223f, redPosZ = 11.661f, redRotX = 13.931f, redRotY = -93.43501f, redRotZ = -0.548f;
    private float greenPosX = 32.8606f, greenPosY = -0.4428f, greenPosZ = 11.5859f, greenRotX = -19.172f, greenRotY = -85.452f, greenRotZ = 6.037f;
    private float bluePosX = 32.7066f, bluePosY = -0.275f, bluePosZ = 11.7225f, blueRotX = 1.927f, blueRotY = -90.0f, blueRotZ = 0.0f;
    private float yellowPosX = 32.7113f, yellowPosY = -0.409f, yellowPosZ = 11.6834f, yellowRotX = 7.488f, yellowRotY = -92.328f, yellowRotZ = 2.695f;


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
            Instantiate(redWire, new Vector3(redPosX, redPosY, redPosZ), Quaternion.Euler(new Vector3(redRotX, redRotY, redRotZ)));
            wiresPlugged = wiresPlugged + 1;
            Debug.Log("wiresPlugged = " + wiresPlugged);
            player.GetComponent<Inventory>().hasRwire = false;
            redWire.tag = ("Untagged");


        }

        else if ((player.GetComponent<Inventory>().hasGwire == true) && (Input.GetMouseButtonDown(0)))
        {
            Instantiate(greenWire, new Vector3(greenPosX, greenPosY, greenPosZ), Quaternion.Euler(new Vector3(greenRotX, greenRotY, greenRotZ)));
            wiresPlugged = wiresPlugged + 1;
            Debug.Log("wiresPlugged = " + wiresPlugged);
            player.GetComponent<Inventory>().hasGwire = false;
            greenWire.tag = ("Untagged");
        }

        else if ((player.GetComponent<Inventory>().hasBwire == true) && (Input.GetMouseButtonDown(0)))
        {
            Instantiate(blueWire, new Vector3(bluePosX, bluePosY, bluePosZ), Quaternion.Euler(new Vector3(blueRotX, blueRotY, blueRotZ)));
            wiresPlugged = wiresPlugged + 1;
            Debug.Log("wiresPlugged = " + wiresPlugged);
            player.GetComponent<Inventory>().hasBwire = false;
            blueWire.tag = ("Untagged");
        }

        else if ((player.GetComponent<Inventory>().hasYwire == true) && (Input.GetMouseButtonDown(0)))
        {
            Instantiate(yellowWire, new Vector3(yellowPosX, yellowPosY, yellowPosZ), Quaternion.Euler(new Vector3(yellowRotX, yellowRotY, yellowRotZ)));
            wiresPlugged = wiresPlugged + 1;
            Debug.Log("wiresPlugged = " + wiresPlugged);
            player.GetComponent<Inventory>().hasYwire = false;
            yellowWire.tag = ("Untagged");
        }
    }
}
