using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance;

    public AudioClip hitSound;
    public AudioClip damageSound;
    public AudioClip killSound;

    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }

    public void PlayDamageSound()
    {
        audioSource.PlayOneShot(damageSound);
    }

    public void PlayKillSound()
    {
        audioSource.PlayOneShot(killSound);
    }
}
