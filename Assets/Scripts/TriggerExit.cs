using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerExit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    public Animator anim;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (door != null)
        {
            if (other.gameObject.tag == "EndDoor")
            {
                anim.SetBool("Close", true);
                anim.SetBool("Open", false);
                other.gameObject.SetActive(false);
            }
                
        }
    }
}
