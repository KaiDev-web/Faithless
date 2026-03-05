using UnityEngine;
using UnityEngine.Audio;

public class StartAudio : MonoBehaviour
{
    public AudioMixer audioManager;
    public AudioClip audioClip;
    private BoxCollider2D boxCollider2D;
    private AudioSource audioSource;
    private bool alreadyPlayed = false;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlaySound(audioClip);
            alreadyPlayed = true;
        }
    }

    public void PlaySound(AudioClip audioClip)
    {
        if (audioSource != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        
    }
}
