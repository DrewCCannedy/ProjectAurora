using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by drew
public class TurnLightsOnWhenPowerOn : MonoBehaviour
{
    public Interaction interaction;
    bool lightsOn = false;
    public GameObject[] doorLights;
    public Material doorLightOn;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform) {
            child.GetComponent<Light>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.powerOn && !lightsOn) {
            foreach (Transform child in transform) {
                child.GetComponent<Light>().enabled = true;
            }
            foreach (GameObject light in doorLights) {
                light.GetComponent<MeshRenderer>().material = doorLightOn;
            }
            lightsOn = true;
        }
    }
}
