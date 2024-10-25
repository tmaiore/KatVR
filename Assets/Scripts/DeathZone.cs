using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "DeathZone")
        {
            this.gameObject.transform.position = new Vector3(0, 1.007f, -13);
        }
        collision.gameObject.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathZone")
        {
            this.gameObject.transform.position = new Vector3(0, 1.007f, -13);
        }
        other.gameObject.SetActive(true);
    }
}
