using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timing : MonoBehaviour
{
    [SerializeField]
    public Image image;

    private bool ok = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ok)
        {
            //faire clignoter le mur (dans le manager de l'épreuve)
        }
    }

    public void checkOn()
    {
        if (image.gameObject.activeSelf)
        {
            //c'est ok, laisser les 2 actifs, stop clignottement, envoyer au manager que celui ci est good
        }
    }
}
