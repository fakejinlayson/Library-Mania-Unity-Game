using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public void PlaySound(AudioClip audioClip, float volume = 0.5f)
    {
        audioSource.PlayOneShot(audioClip, volume);
        Destroy(gameObject, audioClip.length + 0.15f);
    }
}
