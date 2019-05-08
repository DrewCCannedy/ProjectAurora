using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataUpload : MonoBehaviour
{

    GameObject player;
    GameObject playerCam;
    public GameObject redDrive, greenDrive, blueDrive, yellowDrive;
    public bool driveCorrect;
    public bool uploadComplete;
    public bool atCockpit;
    public bool drivePlaced;
    private float rX = 41.518f, rY = 0.9581f, rZ = 8.909f;
    private float gX = 41.515f, gY = 1.1421f, gZ = 9.026f;
    private float bX = 41.5084f, bY = 1.085f, bZ = 9.0273f;
    private float yX = 41.51f, yY = 1.0228f, yZ = 9.0265f;
    private float driveX = 41.518f, driveZ = 8.909f;
    public int whichDrive = 0; //red = 1, green = 2, blue = 3, yellow = 4

    public SubtitleSystem subtitleSystem;

    public Button rdButton, gdButton, bdButton, ydButton;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerCam = GameObject.FindWithTag("MainCamera");
        rdButton.onClick.AddListener(PlugRedDrive);
        gdButton.onClick.AddListener(PlugGreenDrive);
        bdButton.onClick.AddListener(PlugBlueDrive);
        ydButton.onClick.AddListener(PlugYellowDrive);
    }

    // Update is called once per frame
    void Update()
    {
        if (driveCorrect == true && playerCam.GetComponent<Interaction>().powerOn == true)
        {
            
        }
    }

    void PlugRedDrive()
    {
        if (atCockpit == true && uploadComplete == false)
        {
            whichDrive = 1;
            drivePlaced = true;
            Instantiate(redDrive, new Vector3(driveX, rY, driveZ), Quaternion.Euler(new Vector3(0, 100, 0)));
            driveCorrect = true;
            Debug.Log("You have plugged the correct drive!");
            player.GetComponent<Inventory>().hasRdrive = false;
            if (playerCam.GetComponent<Interaction>().powerOn == true) //Only if power is on
            {
                redDrive.tag = ("Untagged");
                subtitleSystem.playUploading = true;
                subtitleSystem.playCode = true;
                uploadComplete = true;
            }
        }
    }

    void PlugGreenDrive()
    {
        if (atCockpit == true && uploadComplete == false)
        {
            whichDrive = 2;
            drivePlaced = true;
            Instantiate(greenDrive, new Vector3(driveX, gY, driveZ), Quaternion.Euler(new Vector3(0, 100, 0)));
            driveCorrect = false;
            Debug.Log("You have plugged the wrong drive!");
            player.GetComponent<Inventory>().hasGdrive = false;
            if (playerCam.GetComponent<Interaction>().powerOn == true) //Only if power is on
            {
                subtitleSystem.playUploading = true;
                subtitleSystem.playError2 = true;
            }
        }
    }

    void PlugBlueDrive()
    {
        if (atCockpit == true && uploadComplete == false)
        {
            whichDrive = 3;
            drivePlaced = true;
            Instantiate(blueDrive, new Vector3(driveX, bY, driveZ), Quaternion.Euler(new Vector3(0, 100, 0)));
            driveCorrect = false;
            Debug.Log("You have plugged the wrong drive!");
            player.GetComponent<Inventory>().hasBdrive = false;
            if (playerCam.GetComponent<Interaction>().powerOn == true) //Only if power is on
            {
                subtitleSystem.playUploading = true;
                subtitleSystem.playError1 = true;
            }
        }
    }

    void PlugYellowDrive()
    {
        if (atCockpit == true && uploadComplete == false)
        {
            whichDrive = 4;
            drivePlaced = true;
            Instantiate(yellowDrive, new Vector3(driveX, yY, driveZ), Quaternion.Euler(new Vector3(0, 100, 0)));
            driveCorrect = false;
            Debug.Log("You have plugged the wrong drive!");
            player.GetComponent<Inventory>().hasYdrive = false;
            if (playerCam.GetComponent<Interaction>().powerOn == true) //Only if power is on
            {
                subtitleSystem.playUploading = true;
                subtitleSystem.playError1 = true;
            }
        }
    }

}
