using Unity.VisualScripting;
using UnityEngine;

public class AxePickupScript : MonoBehaviour, IInteractable
{
    [System.Obsolete]
    public void OnInteraction(){
        gameObject.SetActive(false);
        OutdoorGameState.Instance.hasAxe = true;
        Debug.Log("Picked up Axe");
    }
}
