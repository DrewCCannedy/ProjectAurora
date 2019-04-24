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
    private float driveX = 41.818f, driveY = 0.75f, driveZ = 10.7f;

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

    /*public void PlugDrive()
    {
        if ((player.GetComponent<Inventory>().hasRdrive == true) && (Input.GetMouseButtonDown(0)))
        {
            Instantiate(redDrive, new Vector3(44.1f, 0.75f, 10.7f), Quaternion.Euler(new Vector3(0, 90, 0)));
            driveCorrect = true;
            Debug.Log("You have plugged the correct drive!");
            player.GetComponent<Inventory>().hasRdrive = false;
            
        }
    }
    */

    void PlugRedDrive()
    {
        if (atCockpit == true)
        {
            Instantiate(redDrive, new Vector3(driveX, driveY, driveZ), Quaternion.Euler(new Vector3(0, 90, 0)));
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
        if (atCockpit == true)
        {
            Instantiate(greenDrive, new Vector3(driveX, driveY, driveZ), Quaternion.Euler(new Vector3(0, 90, 0)));
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
        if (atCockpit == true)
        {
            Instantiate(blueDrive, new Vector3(driveX, driveY, driveZ), Quaternion.Euler(new Vector3(0, 90, 0)));
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
        if (atCockpit == true)
        {
            Instantiate(yellowDrive, new Vector3(driveX, driveY, driveZ), Quaternion.Euler(new Vector3(0, 90, 0)));
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
