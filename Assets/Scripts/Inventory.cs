using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public bool hasSpacesuit;
    public bool hasFlashlight;
    public bool hasRwire, hasGwire, hasBwire, hasYwire;
    public bool hasRdrive, hasGdrive, hasBdrive, hasYdrive;

    public bool inventoryMode;
    public Text oxygenText;
    public GameObject oxygenPanel, hudFrame;

    public GameObject inventoryPanel, spacesuitButton, flashlightButton, invisButton;
    public GameObject rwireButton, gwireButton, bwireButton, ywireButton;
    public GameObject rdriveButton, gdriveButton, bdriveButton, ydriveButton;

    public Button invis;
    GameObject keypad;


    int oxygenRemaining = 360;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DecreaseOxygen", 1.0f, 1.0f);
        invis.onClick.AddListener(CloseCurrentPanel);
        keypad = GameObject.FindWithTag("Keypad"); //Needs to keep track of keypad so both panels are not open at the same time
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i") && keypad.GetComponent<PodCode>().keypadMode == false) //I key enters inventory mode
        {
            Debug.Log("Inventory key pressed.");
            if (inventoryMode == false)
            {
                Debug.Log("Entered inventory mode.");
                inventoryMode = true;
            }
        }

        if (inventoryMode == true && Input.GetKeyDown("escape")) //Escape key exists inventory mode
        {
            inventoryMode = false;
        }


        if (inventoryMode == true) //Toggling the inventory panel on and off
        {
            inventoryPanel.SetActive(true);
            invisButton.SetActive(true);
        }

        if (inventoryMode == false)
        {
            inventoryPanel.SetActive(false);
            invisButton.SetActive(false);
        }


        if (hasSpacesuit == true) //Showing the buttons for each item only if the player has picked them up
        {
            hudFrame.SetActive(true);
            oxygenPanel.SetActive(true);
            if (inventoryMode == true)
            {
                spacesuitButton.SetActive(true);
            }
        }
        else
        {
            spacesuitButton.gameObject.SetActive(false);
        }

        if (hasFlashlight == true && inventoryMode == true)
        {
            flashlightButton.SetActive(true);
        }
        else
        {
            flashlightButton.SetActive(false);
        }

        if (hasRwire == true && inventoryMode == true)
        {
            rwireButton.SetActive(true);
        }
        else
        {
            rwireButton.SetActive(false);
        }

        if (hasGwire == true && inventoryMode == true)
        {
            gwireButton.SetActive(true);
        }
        else
        {
            gwireButton.SetActive(false);
        }

        if (hasBwire == true && inventoryMode == true)
        {
            bwireButton.SetActive(true);
        }
        else
        {
            bwireButton.SetActive(false);
        }

        if (hasYwire == true && inventoryMode == true)
        {
            ywireButton.SetActive(true);
        }
        else
        {
            ywireButton.SetActive(false);
        }

        if (hasRdrive == true && inventoryMode == true)
        {
            rdriveButton.SetActive(true);
        }
        else
        {
            rdriveButton.SetActive(false);
        }

        if (hasGdrive == true && inventoryMode == true)
        {
            gdriveButton.SetActive(true);
        }
        else
        {
            gdriveButton.SetActive(false);
        }

        if (hasBdrive == true && inventoryMode == true)
        {
            bdriveButton.SetActive(true);
        }
        else
        {
            bdriveButton.SetActive(false);
        }

        if (hasYdrive == true && inventoryMode == true)
        {
            ydriveButton.SetActive(true);
        }
        else
        {
            ydriveButton.SetActive(false);
        }
    }

    void DecreaseOxygen()
    {
        if (hasSpacesuit == true && oxygenRemaining > 0)
        {
            oxygenRemaining -= 1;
            oxygenText.text = ("Oxygen: " + oxygenRemaining.ToString());
        }

        if (oxygenRemaining < 1)
        {
            //Lose state
            Debug.Log("Oxygen depleted. Game over.");
        }
    }

    void CloseCurrentPanel()
    {
        Debug.Log("Invisible button pressed, inventory script.");
        inventoryMode = false;
    }
}
