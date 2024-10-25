using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if(door!= null)
        {
            if(other.gameObject.tag == "OpenDoor")
            {
                anim.SetBool("OpenEntry", true);
                anim.SetBool("CloseEntry", false);
                other.gameObject.SetActive(false);
            }
            
        }
        

    }
}
