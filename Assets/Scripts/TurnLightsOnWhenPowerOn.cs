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
    public GameObject[] probes;
    public GameObject[] emmisives;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform) {
            child.GetComponent<Light>().enabled = false;
        }
        foreach (GameObject probe in probes) {
            probe.GetComponent<ReflectionProbe>().enabled = false;
        }

        foreach (GameObject light in emmisives) {
            light.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
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
            foreach (GameObject probe in probes) {
                probe.GetComponent<ReflectionProbe>().enabled = true;
            }
            lightsOn = true;
            foreach (GameObject light in emmisives) {
                light.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            }
        }
    }
}
