using UnityEngine;

public class AxeDeleteScript : MonoBehaviour, IInteractable
{
    [SerializeField] private TextAsset inkJSON;
    public void OnInteraction()
    {
        OutdoorGameState.Instance.hasAxe = true;
        gameObject.SetActive(false);
        DialogueManager.Instance.StartDialogue(inkJSON);
    }
}