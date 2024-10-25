using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;

public class Digicode : MonoBehaviour
{
    /// <summary>
    /// Changer le code, mettre la fonction Wrong sur les mauvais et BP correspondant sur les numéros du code
    /// </summary>
    public Image Bouton1;
    public Image Bouton2;
    public Image Bouton3;
    public Image Bouton4;
    public Image Bouton5;
    public Image Bouton6;
    public Image Bouton7;
    public Image Bouton8;
    public Image Bouton9;
    public Image Bouton0;

    public int B1 = 0;
    public int B2 = -1;
    public int B3 = -1;
    public int B4 = -1;

    public Animator anim;

    [SerializeField]
    private GameObject door;

    private Color32 white = new Color32(255, 255, 255, 255);
    private Color32 red = new Color32(255, 0, 0, 255);
    private Color32 green = new Color32(0, 255, 0, 255);

    public void End()
    {
        anim.SetBool("Close", false);
        anim.SetBool("Open", true);
        //faire descendre la porte à la place
    }

    IEnumerator WPPT()
    {
        //code 3493
        for (int i = 0; i < 3; i++)
        {
            Bouton1.color = red;
            Bouton2.color = red;
            Bouton3.color = red;
            Bouton4.color = red;
            Bouton5.color = red;
            Bouton6.color = red;
            Bouton7.color = red;
            Bouton8.color = red;
            Bouton9.color = red;
            Bouton0.color = red;

            yield return new WaitForSeconds(1.0f);

            Bouton1.color = white;
            Bouton2.color = white;
            Bouton3.color = white;
            Bouton4.color = white;
            Bouton5.color = white;
            Bouton6.color = white;
            Bouton7.color = white;
            Bouton8.color = white;
            Bouton9.color = white;
            Bouton0.color = white;
        }

        B1 = 0;
        B2 = -1;
        B3 = -1;
        B4 = -1;
        //en ajouter plus si besoin, ordre jusqu'à 10 ? Ajouter les fonctions correspondantes plus bas 
    }

    public void Good(Image bouton)
    {
        bouton.color = green;
    }

    public void Wrong()
    {
        StartCoroutine(WPPT());
    }

    public void BP1()
    {
        if (B1 == 0)
        {
            Good(Bouton3);
            B1 = 1;
            B2 = 0;
        }
        else
        {
            if(B4 != 0)
            {
                Wrong();
            }
            
        }
    }

    public void BP2()
    {
        if (B2 == 0)
        {
            Good(Bouton4);
            B2 = 1;
            B3 = 0;
        }
        else
        {
            Wrong();
        }
    }

    public void BP3()
    {
        if (B3 == 0)
        {
            Good(Bouton9);
            B3 = 1;
            B4 = 0;
        }
        else
        {
            Wrong();
        }
    }

    public void BP4()
    {
        if (B4 == 0)
        {
            Good(Bouton3);
            End();
        }
        else
        {
            if (B1 != 1)
            {
                Wrong();
            }
            
        }
    }
}
