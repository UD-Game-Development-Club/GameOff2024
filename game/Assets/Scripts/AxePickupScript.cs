using UnityEngine;

public class AxePickupScript : MonoBehaviour, IInteractable
{
    public void OnInteraction()
    {
        gameObject.SetActive(false);
        OutdoorGameState.Instance.HasAxe = true;
        Debug.Log("Picked up Axe");
    }
}