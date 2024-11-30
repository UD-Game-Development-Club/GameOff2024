using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Safe: DialogueInteract
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset incorrectJSON;
    [SerializeField] private TextAsset correctJSON;

    [SerializeField] private GameObject safeUI;

    [SerializeField] private GameObject character;

    [SerializeField] private GameObject key;

    [SerializeField] private AudioClip wrong;
    [SerializeField] private AudioClip right;
    [SerializeField] private AudioClip click;

    bool entering = false;
    bool unlocked = false;
    string passCode = "3862";
    string currentCode = "";

    private GameObject codeString;

    private AudioSource src;

    private void Awake()
    {
        key.SetActive(false);
        safeUI.SetActive(false);
    
        codeString = safeUI.transform.Find("code").gameObject;

        gameObject.AddComponent<AudioSource>();
        src = gameObject.GetComponent<AudioSource>();
    }

    // enter is 0
    public void onButtonClick(int number)
    {
        if (entering)
        {
            src.PlayOneShot(click);

            if(number == 0)
            {
                safeUI.SetActive(false);
                entering = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                int currentCodeInt = int.Parse(currentCode);
                int passCodeInt = int.Parse(passCode);

                if (currentCodeInt == passCodeInt)
                {
                    unlocked = true;
                    src.PlayOneShot(right);
                    DialogueManager.Instance.StartDialogue(correctJSON);
                    character.GetComponent<CharacterController>().locked = false;
                    key.SetActive(true);
                }
                else
                {
                    character.GetComponent<CharacterController>().locked = false;
                    src.PlayOneShot(wrong);
                    DialogueManager.Instance.StartDialogue(incorrectJSON);
                }

                currentCode = "";
            }
            else
            {
                if(currentCode.Length < 4)
                {
                    currentCode += number.ToString();
                }
                else {
                    src.PlayOneShot(wrong);
                }
            }
        }
    }

    public override void OnInteraction()
    {
        if(unlocked || entering)
        {
            return;
        }

        entering = true;
        safeUI.SetActive(true);
        character.GetComponent<CharacterController>().locked = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Update()
    {
        codeString.GetComponent<TextMeshProUGUI>().text = currentCode;

        if(!entering)
        {
            character.GetComponent<CharacterController>().locked = false;
        }
    }
}
