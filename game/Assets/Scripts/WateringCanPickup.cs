using UnityEngine;

public class WateringCanPickup : MonoBehaviour, IInteractable
{
    [SerializeField] private TextAsset wateringCan;
    [System.Obsolete]
    public void OnInteraction(){
        gameObject.SetActive(false);
        OutdoorGameState.Instance.hasCan = true;
        DialogueManager.Instance.StartDialogue(wateringCan);
    }
}
