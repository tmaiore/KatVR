using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallPuzzleManager : MonoBehaviour
{
    /*public Button btn1;
    public Button btn2;*/
    //Ajouter des boutons de couleurs différentes pour différents layers et emplacements de changeurs de même couleur

    public GameObject sphere;
    public GameObject changer1_1;
    public GameObject changer2_1;
    public GameObject changer2_2;
    public GameObject changer3_1;
    public GameObject changer3_2;
    public GameObject changer3_3;

    public Animator anim;
    //En ajouter en fonction du nombre de boutons

    private int position1 = 0;
    private int position2 = 0;
    private int position3 = 0;

    public void Start()
    {
        
    }
    public void btn1Pressed()
    {
        if(position1 == 0)
        {
            //rotation 1_1 et 1_2 de 90° (-135)

            changer1_1.transform.Rotate(0, 90, 0);
            position1 = 1;
        }
        else
        {
            //rotation 1_1 et 1_2 de -90° (-45)
            changer1_1.transform.Rotate(0, -90, 0);
            position1 = 0;
        }
        
    }

    public void btn2Pressed()
    {
        if (position2 == 0)
        {
            //rotation 2_1 et 2_2 de 90° (-135)
            changer2_1.transform.Rotate(0, 90, 0);
            changer2_2.transform.Rotate(0, 90, 0);
            position2 = 1;
        }
        else
        {
            //rotation 2_1 et 2_2 de -90° (-45)
            changer2_1.transform.Rotate(0, -90, 0);
            changer2_2.transform.Rotate(0, -90, 0);
            position2 = 0;
        }

    }

    public void btn3Pressed()
    {
        if (position3 == 0)
        {
            //rotation 2_1 et 2_2 de 90° (-135)
            changer3_1.transform.Rotate(0, 90, 0);
            changer3_2.transform.Rotate(0, 90, 0);
            changer3_3.transform.Rotate(0, 90, 0);
            position3 = 1;
        }
        else
        {
            //rotation 2_1 et 2_2 de -90° (-45)
            changer3_1.transform.Rotate(0, -90, 0);
            changer3_2.transform.Rotate(0, -90, 0);
            changer3_3.transform.Rotate(0, -90, 0);
            position3 = 0;
        }

    }

}
