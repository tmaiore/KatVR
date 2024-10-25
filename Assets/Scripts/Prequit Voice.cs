using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrequitVoice : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        source = other.GetComponent<AudioSource>();
        source.PlayOneShot(clip);
    }
}
