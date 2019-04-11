using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PodCode : MonoBehaviour
{
    public bool keypadMode;
    public GameObject keypadPanel, podDoor, playerCam;
    public Button b0, b1, b2, b3, b4, b5, b6, b7, b8, b9, bDel, bEnter;
    string code;
    string correctCode = "451";
    string memeCode = "666";
    public Text keypadText;

    public SubtitleSystem subtitleSystem;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = GameObject.FindWithTag("MainCamera");
        b0.onClick.AddListener(Add0);
        b1.onClick.AddListener(Add1);
        b2.onClick.AddListener(Add2);
        b3.onClick.AddListener(Add3);
        b4.onClick.AddListener(Add4);
        b5.onClick.AddListener(Add5);
        b6.onClick.AddListener(Add6);
        b7.onClick.AddListener(Add7);
        b8.onClick.AddListener(Add8);
        b9.onClick.AddListener(Add9);
        bDel.onClick.AddListener(Delete);
        bEnter.onClick.AddListener(EnterCode);
    }

    // Update is called once per frame
    void Update()
    {
        if (keypadMode == true && Input.GetKeyDown("escape")) //Escape key exits keypad mode
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

    void Add0()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        { 
            code = code + "0";
            Debug.Log(code);
            keypadText.text = code;
        }
    }

    void Add1()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "1";
            Debug.Log(code);
            keypadText.text = code;
        }
    }

    void Add2()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "2";
            Debug.Log(code);
            keypadText.text = code;
        }
    }

    void Add3()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "3";
            Debug.Log(code);
            keypadText.text = code;
        }
    }

    void Add4()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "4";
            Debug.Log(code);
            keypadText.text = code;
        }
    }

    void Add5()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "5";
            Debug.Log(code);
            keypadText.text = code;
        }
    }

    void Add6()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "6";
            Debug.Log(code);
            keypadText.text = code;
        }
    }

    void Add7()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "7";
            Debug.Log(code);
            keypadText.text = code;
        }
    }

    void Add8()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "8";
            Debug.Log(code);
            keypadText.text = code;
        }
    }

    void Add9()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "9";
            Debug.Log(code);
            keypadText.text = code;
        }
    }

    void Delete()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = "";
            Debug.Log("Code entry cleared.");
            keypadText.text = code;
        }
    }

    void EnterCode()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            if (code == correctCode)
            {
                keypadText.text = ("Access Granted");
                podDoor.SetActive(false);
            } else if (code == memeCode) {
                keypadText.text = ("!!LICK MY TOES!!");
                subtitleSystem.playEasterEgg = true;
            }
            else
            {
                keypadText.text = ("Access Denied");
                subtitleSystem.playError3 = true;
            }
        }

    }


}
