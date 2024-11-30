using UnityEngine;

public class OnWaterTreeRemove : MonoBehaviour, IInteractable
{
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private TextAsset treeWateredDialogue;
    [SerializeField] private GameObject presentSapling;
    [SerializeField] private GameObject growTree;

    [System.Obsolete]
    public void OnInteraction()
    {
        if (!OutdoorGameState.Instance.treeWatered) {
            if(OutdoorGameState.Instance.hasCan){
                OutdoorGameState.Instance.treeWatered = true;
                gameObject.tag = "Untagged";
                presentSapling.SetActive(false);
                growTree.SetActive(true);
                DialogueManager.Instance.StartDialogue(treeWateredDialogue);
            } else {
                DialogueManager.Instance.StartDialogue(inkJSON);
            }
        }
    }
}
