using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Safe: DialogueInteract
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset incorrectJSON;
    [SerializeField] private TextAsset correctJSON;

    [Header("Input Field")]
    [SerializeField] private GameObject inputField;
    public override void OnInteraction()
    {
        DialogueManager.Instance.StartDialogue(inkJSON, GetPassCode);
    }

    private void GetPassCode()
    {
        DialogueManager.Instance.gettingInput = true;
        inputField.SetActive(true);
        InputField _inputField = inputField.GetComponent<InputField>();
    }

    private void ShowKey()
    {
        
    }


}
