using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDriveCheck : MonoBehaviour
{
    GameObject player;
    GameObject cockpit;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        cockpit = GameObject.FindWithTag("Cockpit");
    }

    // Update is called once per frame
    void Update()
    {
        if (cockpit.GetComponent<DataUpload>().whichDrive != 2 && cockpit.GetComponent<DataUpload>().drivePlaced == true)
        {
            player.GetComponent<Inventory>().hasGdrive = true;
            Destroy(this.gameObject);
        }
    }
}
