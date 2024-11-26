using UnityEngine;

public class WateringCanPickup : MonoBehaviour, IInteractable
{
    [System.Obsolete]
    public void OnInteraction(){
        gameObject.SetActive(false);
        OutdoorGameState.Instance.hasCan = true;
        Debug.Log("Picked up Watering Can");
    }
}
