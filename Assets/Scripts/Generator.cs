using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    GameObject player;
    public Interaction camera;
   // public bool powerOn;
    public GameObject redWire;
    public GameObject greenWire;
    public GameObject blueWire;
    public GameObject yellowWire;
    public bool redPlugged, greenPlugged, bluePlugged, yellowPlugged;
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
        if (redPlugged == true && greenPlugged == true && bluePlugged == true && yellowPlugged == true) //All 4 wires plugged, power turns on
        {
            camera.powerOn = true;
            Debug.Log("Ship power online.");
        }

        if (redPlugged == true && greenPlugged != true && bluePlugged == true && yellowPlugged == true) //Play voice line for green wire missing
        {
            Debug.Log("Green wire still required.");
        }

    }

    public void PlugWires()
    {
        if ((player.GetComponent<Inventory>().hasRwire == true) && (Input.GetMouseButtonDown(0)))
        {
            Instantiate(redWire, new Vector3(redPosX, redPosY, redPosZ), Quaternion.Euler(new Vector3(redRotX, redRotY, redRotZ)));
            redPlugged = true;
            Debug.Log("Red wire plugged.");
            player.GetComponent<Inventory>().hasRwire = false;
            redWire.tag = ("Untagged");


        }

        else if ((player.GetComponent<Inventory>().hasGwire == true) && (Input.GetMouseButtonDown(0)))
        {
            Instantiate(greenWire, new Vector3(greenPosX, greenPosY, greenPosZ), Quaternion.Euler(new Vector3(greenRotX, greenRotY, greenRotZ)));
            greenPlugged = true;
            Debug.Log("Green wire plugged.");
            player.GetComponent<Inventory>().hasGwire = false;
            greenWire.tag = ("Untagged");
        }

        else if ((player.GetComponent<Inventory>().hasBwire == true) && (Input.GetMouseButtonDown(0)))
        {
            Instantiate(blueWire, new Vector3(bluePosX, bluePosY, bluePosZ), Quaternion.Euler(new Vector3(blueRotX, blueRotY, blueRotZ)));
            bluePlugged = true;
            Debug.Log("Blue wire plugged.");
            player.GetComponent<Inventory>().hasBwire = false;
            blueWire.tag = ("Untagged");
        }

        else if ((player.GetComponent<Inventory>().hasYwire == true) && (Input.GetMouseButtonDown(0)))
        {
            Instantiate(yellowWire, new Vector3(yellowPosX, yellowPosY, yellowPosZ), Quaternion.Euler(new Vector3(yellowRotX, yellowRotY, yellowRotZ)));
            yellowPlugged = true;
            Debug.Log("Yellow wire plugged.");
            player.GetComponent<Inventory>().hasYwire = false;
            yellowWire.tag = ("Untagged");
        }
    }
}
