using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleSystem : MonoBehaviour
{
    private Text text;
    private Transform panel;
    private List<List<string>> subtitleSections;
    // seconds between text changes
    private int interval = 3;
    // frames per second
    private int fps = 60;
    // count frames 
    private int frameCount = 0;
    // keeping track of which subtitles to play
    private int subtitleCount = 0;

    // section variables
    private bool playIntro = true;
    private bool playSpaceSuit = false;

    // Start is called before the first frame update
    void Start()
    {
        text = transform.Find("Text").GetComponent<Text>();
        panel = transform.Find("Panel");
        panel.gameObject.SetActive(false);
        List<string> subtitles;
        subtitleSections = new List<List<string>>();

        // Intro Text [0]
        subtitles = new List<string>();
        subtitles.Add("AI: Oh good, you’re finally awake.");
        subtitles.Add("AI: I got bored while you were asleep and turned off auto pilot,");
        subtitles.Add("AI: but turns out a disembodied intercom system can’t pilot the ship.");
        subtitles.Add("AI: Sadly, we've struck an asteroid.");
        subtitles.Add("AI: You’re going to have to upload your research and get to an escape pod.");
        subtitles.Add("AI: I believe you left your flashlight on your desk.");
        subtitles.Add("AI: You never clean up after yourself.");
        subtitles.Add("AI: You’ll need it. The power’s out and I know you’re afraid of the dark.");
        subtitleSections.Add(subtitles);

        // SpaceSuit Text [1]
        subtitles = new List<string>();
        subtitles.Add("AI: So, good news: your suit is fully operational.");
        subtitles.Add("AI: Bad news: You didn’t change out the oxygen tank after your last mission.");
        subtitles.Add("AI: Oxygen levels are at ten percent.");
        subtitles.Add("AI: I’d give you about six minutes till you run out.");
        subtitles.Add("AI: Nice knowing you, Aurora.");
        subtitles.Add("AI: Since the door systems are offline you’re gonna have to use the manual lever.");
        subtitleSections.Add(subtitles);
    }

    // Update is called once per frame
    void Update()
    {
        if (playIntro) {
            playIntro = PlaySubtitleSection(0);
        } else if (playSpaceSuit) {
            playSpaceSuit = PlaySubtitleSection(1);
        } else {
            text.text = "";
        }
    }

    // Play a subtitle section, will return true if it runs out of subtitles
    bool PlaySubtitleSection(int section) {
        // run every interval number of seconds
        if (frameCount >= interval * fps) {
            panel.gameObject.SetActive(true);
            // if the end of the subtitles, change the bool
            if (subtitleCount >= subtitleSections[section].Count) {
                subtitleCount = 0;
                panel.gameObject.SetActive(false);
                return false;
            }
            // set subtitle text
            text.text = subtitleSections[section][subtitleCount];
            subtitleCount++;
            frameCount = 0;
        }
        frameCount++;
        return true;
    }

    public void SetPlaySpaceSuit(bool foo) {
        playSpaceSuit = foo;
    }
}
