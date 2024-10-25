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
                    //à randomiser quand il y aura plus d'épreuves de ce type
                    SceneManager.LoadScene(1);
                    break;

                case "Ball":
                    //à randomiser quand il y aura plus d'épreuves de ce type
                    SceneManager.LoadScene(2);
                    break;

                case "Parcours":
                    //à randomiser quand il y aura plus d'épreuves de ce type
                    SceneManager.LoadScene(3);
                    break;

                case "PuzzleModule":
                    //à randomiser quand il y aura plus d'épreuves de ce type
                    SceneManager.LoadScene(4);
                    break;

                case "Surface":
                    //à randomiser quand il y aura plus d'épreuves de ce type
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
