using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{

    GameObject player;
    public Interaction camera;
    public bool atGenerator;
    public GameObject redWire;
    public GameObject greenWire;
    public GameObject blueWire;
    public GameObject yellowWire;
    public bool redPlugged, greenPlugged, bluePlugged, yellowPlugged;
    private float redPosX = 32.903f, redPosY = -0.223f, redPosZ = 11.661f, redRotX = 13.931f, redRotY = -93.43501f, redRotZ = -0.548f;
    private float greenPosX = 32.8606f, greenPosY = -0.4428f, greenPosZ = 11.5859f, greenRotX = -19.172f, greenRotY = -85.452f, greenRotZ = 6.037f;
    private float bluePosX = 32.7066f, bluePosY = -0.275f, bluePosZ = 11.7225f, blueRotX = 1.927f, blueRotY = -90.0f, blueRotZ = 0.0f;
    private float yellowPosX = 32.7113f, yellowPosY = -0.409f, yellowPosZ = 11.6834f, yellowRotX = 7.488f, yellowRotY = -92.328f, yellowRotZ = 2.695f;

    public Button rwButton, gwButton, bwButton, ywButton;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rwButton.onClick.AddListener(PlugRedWire);
        gwButton.onClick.AddListener(PlugGreenWire);
        bwButton.onClick.AddListener(PlugBlueWire);
        ywButton.onClick.AddListener(PlugYellowWire);
    }

    // Update is called once per frame
    void Update()
    {
        if (redPlugged == true && greenPlugged == true && bluePlugged == true && yellowPlugged == true) //All 4 wires plugged, power turns on
        {
            camera.powerOn = true;
        }
    }

    void PlugRedWire()
    {
        if (atGenerator == true)
        {
            Instantiate(redWire, new Vector3(redPosX, redPosY, redPosZ), Quaternion.Euler(new Vector3(redRotX, redRotY, redRotZ)));
            redPlugged = true;
            Debug.Log("Red wire plugged.");
            player.GetComponent<Inventory>().hasRwire = false;
            redWire.tag = ("Untagged");
        }
    }

    void PlugGreenWire()
    {
        if (atGenerator == true)
        { 
            Instantiate(greenWire, new Vector3(greenPosX, greenPosY, greenPosZ), Quaternion.Euler(new Vector3(greenRotX, greenRotY, greenRotZ)));
            greenPlugged = true;
            Debug.Log("Green wire plugged.");
            player.GetComponent<Inventory>().hasGwire = false;
            greenWire.tag = ("Untagged");
        }
    }

    void PlugBlueWire()
    {
        if (atGenerator == true)
        {
            Instantiate(blueWire, new Vector3(bluePosX, bluePosY, bluePosZ), Quaternion.Euler(new Vector3(blueRotX, blueRotY, blueRotZ)));
            bluePlugged = true;
            Debug.Log("Blue wire plugged.");
            player.GetComponent<Inventory>().hasBwire = false;
            blueWire.tag = ("Untagged");
        }
    }

    void PlugYellowWire()
    {
        if (atGenerator == true)
        {
            Instantiate(yellowWire, new Vector3(yellowPosX, yellowPosY, yellowPosZ), Quaternion.Euler(new Vector3(yellowRotX, yellowRotY, yellowRotZ)));
            yellowPlugged = true;
            Debug.Log("Yellow wire plugged.");
            player.GetComponent<Inventory>().hasYwire = false;
            yellowWire.tag = ("Untagged");
        }
    }
}