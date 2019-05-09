using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PodCode : MonoBehaviour
{
    public bool keypadMode;
    public GameObject keypadPanel, podDoor, playerCam, invisButton;
    public Button b0, b1, b2, b3, b4, b5, b6, b7, b8, b9, bDel, bEnter;
    string code;
    string correctCode = "451";
    public Text keypadText;
    public AudioClip wrongCode;
    public Button invis;
    public AudioClip keypad0;
    public AudioClip keypad1;
    public AudioClip keypad2;
    public AudioClip keypad3;
    public AudioClip keypad4;
    public AudioClip keypad5;
    public AudioClip keypad6;
    public AudioClip keypad7;
    public AudioClip keypad8;
    public AudioClip keypad9;
    public SubtitleSystem subtitleSystem;
    public bool winState;
    public Image whiteScreen;
    public GameObject white;

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
        invis.onClick.AddListener(CloseCurrentPanel);
        whiteScreen.canvasRenderer.SetAlpha(0.0f);
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
            invisButton.SetActive(true);
        }

        if (keypadMode == false)
        {
            keypadPanel.SetActive(false);
            invisButton.SetActive(false);
        }

        if (winState == true)
        {
            white.SetActive(true);
            whiteScreen.CrossFadeAlpha(1, 2, false);
        }
    }

    void Add0()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "0";
            Debug.Log(code);
            keypadText.text = code;
            GetComponent<AudioSource>().PlayOneShot(keypad0);
        }
    }

    void Add1()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "1";
            Debug.Log(code);
            keypadText.text = code;
            GetComponent<AudioSource>().PlayOneShot(keypad1);

        }
    }

    void Add2()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "2";
            Debug.Log(code);
            keypadText.text = code;
            GetComponent<AudioSource>().PlayOneShot(keypad2);
        }
    }

    void Add3()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "3";
            Debug.Log(code);
            keypadText.text = code;
            GetComponent<AudioSource>().PlayOneShot(keypad3);
        }
    }

    void Add4()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "4";
            Debug.Log(code);
            keypadText.text = code;
            GetComponent<AudioSource>().PlayOneShot(keypad4);
        }
    }

    void Add5()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "5";
            Debug.Log(code);
            keypadText.text = code;
            GetComponent<AudioSource>().PlayOneShot(keypad5);
        }
    }

    void Add6()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "6";
            Debug.Log(code);
            keypadText.text = code;
            GetComponent<AudioSource>().PlayOneShot(keypad6);
        }
    }

    void Add7()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "7";
            Debug.Log(code);
            keypadText.text = code;
            GetComponent<AudioSource>().PlayOneShot(keypad7);
        }
    }

    void Add8()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "8";
            Debug.Log(code);
            keypadText.text = code;
            GetComponent<AudioSource>().PlayOneShot(keypad8);
        }
    }

    void Add9()
    {
        if (playerCam.GetComponent<Interaction>().powerOn == true)
        {
            code = code + "9";
            Debug.Log(code);
            keypadText.text = code;
            GetComponent<AudioSource>().PlayOneShot(keypad9);
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
                //podDoor.SetActive(false);
                subtitleSystem.playWinState = true;
                winState = true;
            }
            else
            {
                keypadText.text = ("Access Denied");
                subtitleSystem.playError3 = true;
            }
        }

    }

    void CloseCurrentPanel()
    {
        Debug.Log("Invisible button pressed, pod code script.");
        keypadMode = false;
    }


}
