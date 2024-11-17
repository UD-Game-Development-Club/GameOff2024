using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public static Dialogue Instance { get; private set;}
    [SerializeField] private GameObject dialogueText;
    [SerializeField] private GameObject dialogueChoicePanel;


    public GameObject DialogueText => dialogueText;
    public GameObject DialogueChoicePanel => dialogueChoicePanel;

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
