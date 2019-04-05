using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PodCode : MonoBehaviour
{
    public bool keypadMode;
    public GameObject keypadPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown("i")) //I key enters inventory mode
        {
            Debug.Log("Inventory key pressed.");
            if (inventoryMode == false)
            {
                Debug.Log("Entered inventory mode.");
                inventoryMode = true;
            }
        }
       */

        if (keypadMode == true && Input.GetKeyDown("escape")) //Escape key exists inventory mode
        {
            keypadMode = false;
        }


        if (keypadMode == true) //Toggling the keypad panel on and off
        {
            keypadPanel.SetActive(true);
        }

        if (keypadMode == false)
        {
            keypadPanel.SetActive(false);
        }
    }
}
