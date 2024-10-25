using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public GameObject ToDeactivate;
    public GameObject initialObjects;

    private void OnTriggerEnter(Collider other)
    {
        source = other.GetComponent<AudioSource>();
        source.PlayOneShot(clip);
        //slow fade to black

        initialObjects.SetActive(true);
        ToDeactivate.SetActive(false);

        SceneManager.LoadScene(0);
    }
}
