using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private void Awake() {
        
        int numberOfAudioManager = FindObjectsOfType<AudioManager>().Length; 

        if(numberOfAudioManager > 1 )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
