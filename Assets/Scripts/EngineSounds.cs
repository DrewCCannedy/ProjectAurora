using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by drew
public class EngineSounds : MonoBehaviour
{
    public AudioClip[] sounds;
    public Interaction interaction;
    bool playedStartup = false;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.powerOn) {
            if (!playedStartup) {
                source.PlayOneShot(sounds[0]);
                playedStartup = true;
            } else {
                if (!source.isPlaying) {
                    source.loop = true;
                    source.clip = sounds[1];
                    source.Play();
                }
            }
        }
    }
}
