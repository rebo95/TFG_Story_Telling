using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInteraction : MonoBehaviour
{



    [SerializeField]
    Text dialogeText;

    [SerializeField]
    Text questionOption1Text;
    [SerializeField]
    Text questionOption2Text;

    [SerializeField]
    string questionOption1;
    [SerializeField]
    string questionOption2;

    [SerializeField]
    Button questionOption1Button;
    [SerializeField]
    Button questionOption2Button;

    [SerializeField]
    GameObject panel;


    private int numOfDialogues;
    private int numExtraDialogues;

    [SerializeField]
    List<string> dialoges;

    [SerializeField]
    int questionIndex;


    private bool questCompleted = false;

    private int interactionIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        numOfDialogues = dialoges.Count + 1;// Debemos tener en cuenta la pregunta
        dialoges.Add("");
        questionOption1Text.text = questionOption1;
        questionOption2Text.text = questionOption2;

    }

    // Update is called once per frame
    void Update()
    {  
    }

    public void Interact()
    {
        interactionIndex++;
        if (interactionIndex >= numOfDialogues)
            interactionIndex = -1;
        else UpdateDialogue();

        UpdatePanel();

    }

    private void UpdatePanel()
    {
        if (interactionIndex == -1)
        {
            panel.SetActive(false);
            RemoveExtraLines();

            if (questCompleted)
            {
                gameObject.SetActive(false);
            }

        }
        else if (interactionIndex == 0) {
            panel.SetActive(true);
        }
        else if (interactionIndex == questionIndex)
        {
            questionOption1Button.gameObject.SetActive(true);
            questionOption2Button.gameObject.SetActive(true);
        }else if (interactionIndex == questionIndex + 1)
        {
            questionOption1Button.gameObject.SetActive(false);
            questionOption2Button.gameObject.SetActive(false);
        }
    }

    private void UpdateDialogue()
    {
        string displayedText = "";
        displayedText = dialoges[interactionIndex];
        dialogeText.text = displayedText;
    }
    

    public void Button1Action()
    {

        questCompleted = true;
        AddDialogeLine("Correcto");
        AddDialogeLine("Pues...");
        AddDialogeLine("Yo ya me voy");
        AddDialogeLine("...");

        Interact();
    }

    public void Button2Action()
    {
        AddDialogeLine("HAHAHAHAHAAH");
        AddDialogeLine("NO");


        Interact();

    }

    private void AddDialogeLine(string line) {
        dialoges.Add(line);
        numOfDialogues++;
        numExtraDialogues++;
    }

    private void RemoveExtraLines() {

        int firstExtraLineIndex = numOfDialogues - numExtraDialogues;
        dialoges.RemoveRange(firstExtraLineIndex, numExtraDialogues);
        numOfDialogues -= numExtraDialogues;
        numExtraDialogues = 0;
    }
}
