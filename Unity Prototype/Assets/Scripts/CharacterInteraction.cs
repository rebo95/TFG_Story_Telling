using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField]
    Text dialogeText;

    [SerializeField]
    GameObject panel;


    private int numOfDialogues;

    [SerializeField]
    List<string> dialoges;

    private int interactionIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        numOfDialogues = dialoges.Count;
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
        }
        else panel.SetActive(true);
    }

    private void UpdateDialogue()
    {
        string displayedText = "";
        displayedText = dialoges[interactionIndex];
        dialogeText.text = displayedText;
    }
    
}
