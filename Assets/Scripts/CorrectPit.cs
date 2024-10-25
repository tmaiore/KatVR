using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class CorrectPit : MonoBehaviour
{

    public GameObject door;
    public Animator anim;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Faux")
        {
            this.transform.position = new Vector3(-37.8f, 24f, 0f);
        }
        if(other.gameObject.tag == "Correcte")
        {
            anim.SetBool("Close", false);
            anim.SetBool("Open", true);
        }

    }
}
