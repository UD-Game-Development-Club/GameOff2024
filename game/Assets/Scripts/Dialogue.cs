using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public static Dialogue Instance { get; private set;}
    [SerializeField] private GameObject dialogueText;

    public GameObject DialogueText
    {
        get { return dialogueText; }
        private set { dialogueText = value; }
    }

    [SerializeField] private GameObject dialogueChoicePanel;

    public GameObject DialogueChoicePanel 
    {
        get { return dialogueChoicePanel;}
        private set { dialogueChoicePanel = value;}
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start() {
        if(DialogueManager.Instance == null)
        {
            GameObject dialogueManager = new GameObject("DialogueManager");
            dialogueManager.AddComponent<DialogueManager>();
        }
    }
}
