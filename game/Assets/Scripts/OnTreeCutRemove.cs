using UnityEngine;

public class OnTreeCutRemove : MonoBehaviour, IInteractable
{
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private TextAsset inkJSONTreeCut;
    [SerializeField] private OutdoorGameState outdoorGameState;
    
    public void OnInteraction() {
        if (outdoorGameState.hasAxe) {
            gameObject.SetActive(false);
            outdoorGameState.treeCut = true;
            DialogueManager.Instance.StartDialogue(inkJSONTreeCut);
        } else {
            // TODO: Add animation
            Debug.Log("Need Axe");
            DialogueManager.Instance.StartDialogue(inkJSON);
        }
    }
}
