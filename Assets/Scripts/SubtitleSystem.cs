using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// created by drew
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

    // audio
    [System.Serializable]
    public class AudioClips {
        public AudioClip[] clips;
    }
    public AudioClips[] audioClips;
    public AudioSource audioSource;    

    // section variables
    private bool playIntro = true;
    public bool playFlashLight = true;
    public bool playSpaceSuit = false;
    public bool playBridge = false; 
    // this makes sure the bridge audio only plays once, since its based on player location
    public bool playBridgeOnce = true;
    public bool playGreenWire = false;
    public bool playDoorHint = false;
    public bool playPowerOn = false;
    public bool playDriveWarn = false;
    public bool playDriveWarnOnce = true;
    public bool playUploading = false;
    public bool playError1 = false;
    public bool playError2 = false;
    public bool playEasterEgg = false;
    public bool playError3 = false;
    public bool play30 = false;
    public bool play90 = false;
    public bool play270 = false;

    public bool playWinState = false;
    public bool playCode = false;

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
        subtitles.Add("AI: We've struck an asteroid and you’re going to have to upload your research and get to an escape pod.");
        subtitleSections.Add(subtitles);

        // SpaceSuit Text [1]
        subtitles = new List<string>();
        subtitles.Add("AI: So, good news: your suit is fully operational.");
        subtitles.Add("AI: Bad news: You didn’t change out the oxygen tank after your last mission.");
        subtitles.Add("AI: Oxygen levels are at ten percent.");
        subtitles.Add("AI: I’d give you about six minutes till you run out.");
        subtitles.Add("AI: Nice knowing you, Captain.");
        // subtitles.Add("AI: Since the door systems are offline you’re gonna have to use the manual lever.");
        subtitleSections.Add(subtitles);

        // FlashLight Text [2]
        subtitles = new List<string>();
        subtitles.Add("AI: I'm pretty sure you left your light on your desk since you never clean up after yourself.");
        subtitles.Add("AI: You’ll need it. The power’s out and I know you’re afraid of the dark.");
        subtitleSections.Add(subtitles);

        // Bridge Text [3]
        subtitles = new List<string>();
        subtitles.Add("AI: Looks like the power’s out.");
        subtitles.Add("AI: You’re a smart girl, I’m sure you can get that backup generator running.");
        subtitles.Add("AI: Well, you have to otherwise we’re stranded.");
        subtitleSections.Add(subtitles);

        // Green Wire Text [4]
        subtitles = new List<string>();
        subtitles.Add("AI: And the green wire’s missing! What luck! You’re in for a real treat if you don’t have another somewhere.");
        subtitleSections.Add(subtitles);

        // Door Hint Text [5]
        subtitles = new List<string>();
        subtitles.Add("AI: Oh, one more important thing I forgot to mention.");
        subtitles.Add("AI: There’s a breach in the bridge and oxygen levels are plummeting.");
        subtitles.Add("AI: You’re dead meat if you don’t put your suit on.");
        subtitleSections.Add(subtitles);

        // Power On Text [6]
        subtitles = new List<string>();
        subtitles.Add("AI: Backup generator connected. Main power is now online. Congratulations…");
        subtitles.Add("AI: Make sure to send out your research data before you go.");
        subtitles.Add("AI: Your boss wouldn’t be happy if you came back empty-handed.");
        subtitles.Add("AI: Didn’t you disconnect your terminal in order to turn on the generator?");
        subtitles.Add("AI: Well, looks like someone’s getting fired. Sucks.");
        subtitles.Add("AI: You know… you could just take out the hard drive and hook it up to the bridge terminal instead.");
        subtitleSections.Add(subtitles);

        // Drive Warn Text [7]
        subtitles = new List<string>();
        subtitles.Add("AI: I hope you remember which drive it is");
        subtitles.Add("AI: Don't ask me. I don't know which one you'd put MARS terraforming data on.");
        subtitleSections.Add(subtitles);

        // Uploading Text [8]
        subtitles = new List<string>();
        subtitles.Add("AI: Reading contents of drive now...");
        subtitleSections.Add(subtitles);

        // Error 1 Text [9]
        subtitles = new List<string>();
        subtitles.Add("AI: Wrong. Try again.");
        subtitleSections.Add(subtitles);

        // Error 2 Text [10]
        subtitles = new List<string>();
        subtitles.Add("AI: Wrong. I can help you write a resignation letter so you don't get fired. Or a eulogy.");
        subtitleSections.Add(subtitles);

        // Easter Egg Text [11]
        subtitles = new List<string>();
        subtitles.Add("AI: QUENTIN TARANTINO QUENTIN TARANTINO QUENTIN TARANTINO");
        subtitleSections.Add(subtitles);

        // Error 3 Text [12]
        subtitles = new List<string>();
        subtitles.Add("AI: Wait, you seriously don't know the code to your own escape pod?");
        subtitles.Add("AI: There has to be somewhere you can find it. Hurry!");
        subtitleSections.Add(subtitles);

        // Win State Text [13]
        subtitles = new List<string>();
        subtitles.Add("AI: Finally! Took you long enough.");
        subtitles.Add("AI: Wait..You are coming back for my AI chip, right?.....RIGHT?!");
        subtitleSections.Add(subtitles);

        // Win State Text [14]
        subtitles = new List<string>();
        subtitles.Add("AI: Finally! Took you long enough.");
        subtitles.Add("AI: Wait..You are coming back for my AI chip, right?.....RIGHT?!");
        subtitleSections.Add(subtitles);

        // Correct Drive Text [15]
        subtitles = new List<string>();
        subtitles.Add("AI: Here we are. I can see all your files. Uploading research data now.");
        subtitleSections.Add(subtitles);

        // Warning 30 Text [16]
        subtitles = new List<string>();
        subtitles.Add("AI: Suit oxygen levels down to 0.83%, 30 seconds left.");
        subtitles.Add("AI: If you don't have a plan, at least its been fun.");
        subtitleSections.Add(subtitles);

        // Warning 90 Text [17]
        subtitles = new List<string>();
        subtitles.Add("AI: Suit oxygen levels down to 2.5%, 90 seconds left.");
        subtitleSections.Add(subtitles);

        // Warning 270 Text [18]
        subtitles = new List<string>();
        subtitles.Add("AI: Suit oxygen levels down to 5%, you have about 3 minutes.");
        subtitleSections.Add(subtitles);
    }

    // Update is called once per frame
    void Update()
    {
        if (playIntro) {
            playIntro = PlayAudioSection(0);
        } else if (play30) {
            play30 = PlayAudioSection(16);
        } else if (play90) {
            play90 = PlayAudioSection(17);
        } else if (play270) {
            play270 = PlayAudioSection(18);
        } else if (playFlashLight && Time.time > 18f) {
            playFlashLight = PlayAudioSection(2);
        } else if (playDoorHint && !playFlashLight) {
            playDoorHint = PlayAudioSection(5);
        } else if (playSpaceSuit) {
            playSpaceSuit = PlayAudioSection(1);
        } else if (playBridge) {
            playBridge = PlayAudioSection(3);
        } else if (playGreenWire) {
            playGreenWire = PlayAudioSection(4);
        } else if (playPowerOn) {
            playPowerOn = PlayAudioSection(6);
        } else if (playDriveWarn) {
            playDriveWarn = PlayAudioSection(7);
        } else if (playUploading) {
            playUploading =PlayAudioSection(8);
        } else if (playError1) {
            playError1 = PlayAudioSection(9);
        } else if (playError2) {
            playError2 = PlayAudioSection(10);
        } else if (playEasterEgg) {
            playEasterEgg = PlayAudioSection(11);
        } else if (playError3) {
            playError3 = PlayAudioSection(12);
        } else if (playWinState) {
            playWinState = PlayAudioSection(14);
        } else if (playCode) {
            playCode = PlayAudioSection(15);
        } else {
            text.text = "";
        }
    }

    // plays audio with subtitles
    bool PlayAudioSection(int section) {
        if (!audioSource.isPlaying) {
            // if all clips are played, move on
            if (subtitleCount >= subtitleSections[section].Count) {
                subtitleCount = 0;
                panel.gameObject.SetActive(false);
                return false;
            }
            panel.gameObject.SetActive(true);
            // set subtitle text
            text.text = subtitleSections[section][subtitleCount];
            // play next audio
            audioSource.PlayOneShot(audioClips[section].clips[subtitleCount]);
            subtitleCount++;
        }
        return true;
    }    

    // Use this without audio
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
}
