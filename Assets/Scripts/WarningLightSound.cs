using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// made by drew
public class WarningLightSound : MonoBehaviour
{
    AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(PlaySoundAfterSeconds());
    }

    IEnumerator PlaySoundAfterSeconds()
    {
        while(true) {
            source.PlayOneShot(clip);
            yield return new WaitForSeconds(10);
        }
    }
}
