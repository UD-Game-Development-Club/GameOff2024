using UnityEngine;

public class WateringCanPickup : MonoBehaviour, IInteractable
{
    public void OnInteraction()
    {
        gameObject.SetActive(false);
        OutdoorGameState.Instance.HasCan = true;
        Debug.Log("Picked up Watering Can");
    }
}