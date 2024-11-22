using System;
using UnityEngine;

public class DialogueInteract : MonoBehaviour, IInteractable
{
    [Header("Ink JSON")]
    [SerializeField] protected TextAsset inkJSON;
    [SerializeField] private Action callback;

    public virtual void OnInteraction()
    {
        DialogueManager.Instance.StartDialogue(inkJSON);
    }
}
