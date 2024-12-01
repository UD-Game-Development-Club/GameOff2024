using UnityEngine;
using UnityEngine.UI;

public class Note : DialogueInteract
{
    [SerializeField] GameObject noteInspector;
    [SerializeField] Image noteImage;
    [SerializeField] Sprite noteSprite;
    public override void OnInteraction()
    {
        noteInspector.SetActive(true);
        noteImage.sprite = noteSprite;
        DialogueManager.Instance.StartDialogue(inkJSON, EndDialogue);
    }

    private void EndDialogue()
    {
        noteInspector.SetActive(false);
    }
}
