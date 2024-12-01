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
        GameObject note = GameObject.Find("Library Puzzle Win Code");
        note.SetActive(true);
    }
}
