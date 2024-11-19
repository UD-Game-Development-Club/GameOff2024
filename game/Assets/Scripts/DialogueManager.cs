using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialogueChoicePrefab;
    private GameObject dialoguePanel;
    private TextMeshProUGUI dialogueText;
    private RectTransform dialogueChoicesPanel;

    [Header("Game Input")]
    [SerializeField] private GameInput input;

    [Header("Text Sound Effect")]
    [SerializeField] private AudioClip textSFX;
    private AudioSource audioSource;

    private Story currentStory;
    private bool dialogueActive;
    private Coroutine displayTextCoroutine;
    private string currentDialogue;
    private int choiceCount;
    public static DialogueManager Instance { get; private set;}
    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start() 
    {
        // Set dialog variables
        dialoguePanel = Dialogue.Instance.gameObject;
        dialogueChoicesPanel = Dialogue.Instance.DialogueChoicePanel.GetComponent<RectTransform>();
        dialogueText = Dialogue.Instance.DialogueText.GetComponent<TextMeshProUGUI>();

        dialogueActive = false;
        dialoguePanel.SetActive(false);

        // Set up typing sound effect
        audioSource = GameObject.FindWithTag("Player").AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.clip = textSFX;
        audioSource.volume = 0.25f;
    }

    private void Update() 
    {
        if(!dialogueActive)
        {
            return;
        }

        if(input.GetAttackClick())
        {
            if(displayTextCoroutine != null)
            {
                FinishCurrentDialog();
            }
            else if(choiceCount == 0)
            {
                ContinueDialog();
            }
        }
    }
    
    public void StartDialogue(TextAsset inkJSON)
    {
        if(!dialogueActive)
        {
            currentStory = new Story(inkJSON.text);
            dialogueActive = true;
            dialoguePanel.SetActive(true);
            
            // Disable move and camera inputs
            input.DisableMoveInput();
            input.DisableLook();

            // Unlock and show mouse cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Show first Dialogue
            ContinueDialog();
        }
    }

    private void ExitDialog()
    {
        dialogueActive = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        // Enable Inputs
        input.EnableMoveInput();
        input.EnableLook();

        // Disable and hide mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void ContinueDialog()
    {
        // Remove all choices if any
        foreach(Transform child in dialogueChoicesPanel)
        {
            Destroy(child.gameObject);
        }
        if(currentStory.canContinue)
        {
            currentDialogue = currentStory.Continue();
            dialogueText.text = "";
            displayTextCoroutine = StartCoroutine(DisplayText());
        }
        else
        {
            ExitDialog();
        }
    }

    private IEnumerator DisplayText()
    {  
        audioSource.Play();
        foreach(char c in currentDialogue)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        audioSource.Stop();
        DisplayChoices();
        displayTextCoroutine = null;
    }

    private void DisplayChoices()
    {
        List<Choice> choices = currentStory.currentChoices;
        choiceCount = choices.Count;
        int currIndex = 0;   
        foreach(Choice choice in choices)
        {
            GameObject choiceButton = Instantiate(dialogueChoicePrefab, dialogueChoicesPanel);
            TextMeshProUGUI choiceText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
            DialogueButton choiceButtonScript = choiceButton.GetComponentInChildren<DialogueButton>();
            choiceText.text = choice.text;
            choiceButtonScript.choiceIndex = currIndex;
            currIndex++;
        }
    }

    private void FinishCurrentDialog()
    {
        StopCoroutine(displayTextCoroutine);
        displayTextCoroutine = null;
        audioSource.Stop();
        dialogueText.text = currentDialogue;
        DisplayChoices();
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueDialog();
    }
}
