using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// made by drew, copied over by noah for other sounds
public class ShakeDelay : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(ShakeAfterSeconds());
    }

    IEnumerator ShakeAfterSeconds()
    {
        while (true)
        {
            
            Debug.Log("Shake");
            yield return new WaitForSeconds(5);
        }
    }
}