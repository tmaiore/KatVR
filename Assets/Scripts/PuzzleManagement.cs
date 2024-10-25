using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzleManagement : MonoBehaviour
{
    [SerializeField]
    private string tagg;

    [SerializeField]
    private Panel panel;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSelect(SelectEnterEventArgs args)
    {
        //IXRSelectInteractable objName = interactor.GetOldestInteractableSelected();
        //GameObject obj = objName.transform.gameObject;
        tagg = args.interactableObject.transform.gameObject.tag;// obj.tag;

        switch (tagg)
        {
            case "PuzzlePiece1":
                if (gameObject.tag == "PuzzlePanel1")
                {
                    panel.correctPlus();
                    break;
                }
                else
                {
                    panel.incorrectPlus();
                    break;
                }

            case "PuzzlePiece2":
                if (gameObject.tag == "PuzzlePanel2")
                {
                    panel.correctPlus();
                    break;
                }
                else
                {
                    panel.incorrectPlus();
                    break;
                }

            case "PuzzlePiece3":
                if (gameObject.tag == "PuzzlePanel3")
                {
                    panel.correctPlus();
                    break;
                }
                else
                {
                    panel.incorrectPlus();
                    break;
                }

            case "PuzzlePiece4":
                if (gameObject.tag == "PuzzlePanel4")
                {
                    panel.correctPlus();
                    break;
                }
                else
                {
                    panel.incorrectPlus();
                    break;
                }

            case "PuzzlePiece5":
                if (gameObject.tag == "PuzzlePanel5")
                {
                    panel.correctPlus();
                    break;
                }
                else
                {
                    panel.incorrectPlus();
                    break;
                }

            case "PuzzlePiece6":
                if (gameObject.tag == "PuzzlePanel6")
                {
                    panel.correctPlus();
                    break;
                }
                else
                {
                    panel.incorrectPlus();
                    break;
                }

            case "PuzzlePiece7":
                if (gameObject.tag == "PuzzlePanel7")
                {
                    panel.correctPlus();
                    break;
                }
                else
                {
                    panel.incorrectPlus();
                    break;
                }

            case "PuzzlePiece8":
                if (gameObject.tag == "PuzzlePanel8")
                {
                    panel.correctPlus();
                    break;
                }
                else
                {
                    panel.incorrectPlus();
                    break;
                }

            case "PuzzlePiece9":
                if (gameObject.tag == "PuzzlePanel9")
                {
                    panel.correctPlus();
                    break;
                }
                else
                {
                    panel.incorrectPlus();
                    break;
                }

            default: break;

        }

    }


    public void OnDeselect(SelectExitEventArgs args)
    {

        tagg = args.interactableObject.transform.gameObject.tag;// obj.tag;

        switch (tagg)
        {
            case "PuzzlePiece1":
                if (gameObject.tag == "PuzzlePanel1")
                {
                    panel.correctMoins();
                    break;
                }
                else
                {
                    panel.incorrectMoins();
                    break;
                }

            case "PuzzlePiece2":
                if (gameObject.tag == "PuzzlePanel2")
                {
                    panel.correctMoins();
                    break;
                }
                else
                {
                    panel.incorrectMoins();
                    break;
                }

            case "PuzzlePiece3":
                if (gameObject.tag == "PuzzlePanel3")
                {
                    panel.correctMoins();
                    break;
                }
                else
                {
                    panel.incorrectMoins();
                    break;
                }

            case "PuzzlePiece4":
                if (gameObject.tag == "PuzzlePanel4")
                {
                    panel.correctMoins();
                    break;
                }
                else
                {
                    panel.incorrectMoins();
                    break;
                }

            case "PuzzlePiece5":
                if (gameObject.tag == "PuzzlePanel5")
                {
                    panel.correctMoins();
                    break;
                }
                else
                {
                    panel.incorrectMoins();
                    break;
                }

            case "PuzzlePiece6":
                if (gameObject.tag == "PuzzlePanel6")
                {
                    panel.correctMoins();
                    break;
                }
                else
                {
                    panel.incorrectMoins();
                    break;
                }

            case "PuzzlePiece7":
                if (gameObject.tag == "PuzzlePanel7")
                {
                    panel.correctMoins();
                    break;
                }
                else
                {
                    panel.incorrectMoins();
                    break;
                }

            case "PuzzlePiece8":
                if (gameObject.tag == "PuzzlePanel8")
                {
                    panel.correctMoins();
                    break;
                }
                else
                {
                    panel.incorrectMoins();
                    break;
                }

            case "PuzzlePiece9":
                if (gameObject.tag == "PuzzlePanel9")
                {
                    panel.correctMoins();
                    break;
                }
                else
                {
                    panel.incorrectMoins();
                    break;
                }

            default: break;

        }
    }
}
