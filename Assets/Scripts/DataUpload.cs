using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataUpload : MonoBehaviour
{

    GameObject player;
    public GameObject redDrive;
    public bool driveCorrect;
    public bool uploadComplete;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
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
}
