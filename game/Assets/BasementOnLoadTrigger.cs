using UnityEngine;

public class BasementOnLoadTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private void Update()
    {
        DialogueManager.Instance.StartDialogue(inkJSON);
        Destroy(gameObject);
    }
}