using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixer : MonoBehaviour
{
    public AudioSource audioSource;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            if (audioSource != null)
            {
                audioSource.Stop();

                Debug.Log("Music Stopped");
            }
            else
            {
                Debug.Log("Music is still going.");
            }
        }
    }
}
