using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataUpload : MonoBehaviour
{

    GameObject player;
    public GameObject redDrive, greenDrive, blueDrive, yellowDrive;
    public bool driveCorrect;
    public bool uploadComplete;
    private float driveX = 41.818f, driveY = 0.75f, driveZ = 10.7f;

    public Button rdButton, gdButton, bdButton, ydButton;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rdButton.onClick.AddListener(PlugRedDrive);
        gdButton.onClick.AddListener(PlugGreenDrive);
        bdButton.onClick.AddListener(PlugBlueDrive);
        ydButton.onClick.AddListener(PlugYellowDrive);
    }

    // Update is called once per frame
    void Update()
    {
        if (driveCorrect == true)
        {
            Debug.Log("Data uploading.");
        }
    }

    public void PlugDrive()
    {
        if ((player.GetComponent<Inventory>().hasRdrive == true) && (Input.GetMouseButtonDown(0)))
        {
            Instantiate(redDrive, new Vector3(44.1f, 0.75f, 10.7f), Quaternion.Euler(new Vector3(0, 90, 0)));
            driveCorrect = true;
            Debug.Log("You have plugged the correct drive!");
            player.GetComponent<Inventory>().hasRdrive = false;
        }
    }

    void PlugRedDrive()
    {
        Instantiate(redDrive, new Vector3(driveX, driveY, driveZ), Quaternion.Euler(new Vector3(0, 90, 0)));
        driveCorrect = true;
        Debug.Log("You have plugged the correct drive!");
        player.GetComponent<Inventory>().hasRdrive = false;
        redDrive.tag = ("Untagged");
    }

    void PlugGreenDrive()
    {
        Instantiate(greenDrive, new Vector3(driveX, driveY, driveZ), Quaternion.Euler(new Vector3(0, 90, 0)));
        driveCorrect = false;
        Debug.Log("You have plugged the wrong drive!");
        player.GetComponent<Inventory>().hasGdrive = false;
    }

    void PlugBlueDrive()
    {
        Instantiate(blueDrive, new Vector3(driveX, driveY, driveZ), Quaternion.Euler(new Vector3(0, 90, 0)));
        driveCorrect = false;
        Debug.Log("You have plugged the wrong drive!");
        player.GetComponent<Inventory>().hasBdrive = false;
    }

    void PlugYellowDrive()
    {
        Instantiate(yellowDrive, new Vector3(driveX, driveY, driveZ), Quaternion.Euler(new Vector3(0, 90, 0)));
        driveCorrect = false;
        Debug.Log("You have plugged the wrong drive!");
        player.GetComponent<Inventory>().hasYdrive = false;
    }

}
