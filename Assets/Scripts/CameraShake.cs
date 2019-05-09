using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // shake sound
    public AudioClip crash;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    public int timeSinceShake = 0;
    private bool soundPlayed = false;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (timeSinceShake > 1000)
        {
            
            if (shakeDuration > 0)
            {
                
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
                if(!soundPlayed){
                    GetComponent<AudioSource>().PlayOneShot(crash);
                }
                soundPlayed = true;
                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeDuration = 1f;
                soundPlayed = false;
                camTransform.localPosition = originalPos;
                timeSinceShake = 0;
            }
        }

        timeSinceShake++;
    }

    

   
}
