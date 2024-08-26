using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    // Singleton
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        // Spawn in game object
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        // Assign audio clip
        audioSource.clip = audioClip;

        // Assign volume
        audioSource.volume = volume;

        // Play audio clip
        audioSource.Play();

        // Get length of audio clip
        float clipLength = audioSource.clip.length;

        // Destroy the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
