using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{   
    public Animator anim;
    public GameObject g;
    public void OnEnterTriggerEnd()
    {
        anim.SetBool("Fade", true);
    }

    public void OnEnterTriggerStart()
    {
        anim.SetBool("Fade", false);
    }

    public void OnFadeComplete()
    {
        if(g != null)
        {
            switch (g.tag)
            {
                case "Digicode":
                    //� randomiser quand il y aura plus d'�preuves de ce type
                    SceneManager.LoadScene(1);
                    break;

                case "Ball":
                    //� randomiser quand il y aura plus d'�preuves de ce type
                    SceneManager.LoadScene(2);
                    break;

                case "Parcours":
                    //� randomiser quand il y aura plus d'�preuves de ce type
                    SceneManager.LoadScene(3);
                    break;

                case "PuzzleModule":
                    //� randomiser quand il y aura plus d'�preuves de ce type
                    SceneManager.LoadScene(4);
                    break;

                case "Surface":
                    //� randomiser quand il y aura plus d'�preuves de ce type
                    SceneManager.LoadScene(0);
                    break;

                default: break;
            }
        }
        else
        {
            OnEnterTriggerStart();
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        g = other.gameObject;

        if (g.tag != "OpenDoor" || g.tag == "PreExit")
        {
            OnEnterTriggerEnd();
            OnFadeComplete();
        }
    }
}
