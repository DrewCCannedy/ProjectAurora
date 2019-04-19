using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    AudioSource toggleLight;

    // Start is called before the first frame update
    void Start()
    {
        toggleLight = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e")) {
            GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
            toggleLight.Play();
        }
    }
}
