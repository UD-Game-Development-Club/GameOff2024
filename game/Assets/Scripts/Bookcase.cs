using System;
using UnityEngine;

public class Bookcase : DialogueInteract
{
    [SerializeField] private String[] books;
    [SerializeField] private int validBook = -1;
    [SerializeField] private GameObject note;

    public override void OnInteraction()
    {
        DialogueManager.Instance.StartDialogue(inkJSON, CorrectBook);
    }

    private void CorrectBook()
    {
        if(note != null)
        {
            note.SetActive(true);
        }
    }
}
