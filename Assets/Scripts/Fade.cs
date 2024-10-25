using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Animator anim;
    public void OnEnterTriggerEnd()
    {
        anim.SetBool("Fade", true);
    }

    public void OnEnterTriggerStart()
    {
        anim.SetBool("Fade", true);
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(0);
    }
}
