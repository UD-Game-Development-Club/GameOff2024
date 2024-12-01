using System;
using UnityEngine;

public class Bookcase : DialogueInteract
{
    [SerializeField] private String[] books;
    [SerializeField] private int validBook = -1;
    [SerializeField] private TextAsset correctJSON = null;

    public override void OnInteraction()
    {
        DialogueManager.Instance.StartDialogue(inkJSON, ChooseBook);
    }

    private void ChooseBook()
    {
        string chosenBook = "";
        int choice = DialogueManager.Instance.currentChoice;
        if(books.Length >= choice)
        {
            chosenBook = books[DialogueManager.Instance.currentChoice];
        }

        if (chosenBook == books[validBook] && correctJSON != null)
        {
            DialogueManager.Instance.StartDialogue(correctJSON, enableNote);
        }
    }

    public void enableNote()
    {
        GameObject note = GameObject.Find("Library Puzzle Win Code");
        note.SetActive(true);
    }

}
