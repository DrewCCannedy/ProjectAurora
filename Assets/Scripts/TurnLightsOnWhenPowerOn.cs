using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by drew
public class TurnLightsOnWhenPowerOn : MonoBehaviour
{
    public Interaction interaction;
    bool lightsOn = false;

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
            lightsOn = true;
        }
    }
}
