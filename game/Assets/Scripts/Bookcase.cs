using System;
using UnityEngine;

public class Bookcase : DialogueInteract
{
    [SerializeField] private String[] books;
    
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
        Debug.Log(chosenBook);
    }

}
