using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.XR.Interaction.Toolkit;

public class Panel : MonoBehaviour
{


    [SerializeField]
    public int correct = 0;

    [SerializeField]
    public int incorrect = 0;

    [SerializeField] 
    public int notPlaced = 9;

    public GameObject door;
    public Animator anim;

    /*[SerializeField]
    AudioSource source;
    AudioClip clip;*/

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (correct == 9)
        {
            anim.SetBool("Close", false);
            anim.SetBool("Open", true);

            correct++;
        }
    }

    public void correctPlus()
    {
        correct++;
        notPlaced--;
    }

    public void correctMoins()
    {
        correct--;
        notPlaced++;
    }

    public void incorrectPlus()
    {
        incorrect++;
        notPlaced--;
    }

    public void incorrectMoins()
    {
        incorrect--;
        notPlaced++;
    }

}
