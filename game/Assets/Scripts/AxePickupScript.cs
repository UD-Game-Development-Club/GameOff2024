using Unity.VisualScripting;
using UnityEngine;

public class AxePickupScript : MonoBehaviour, IInteractable
{
    [System.Obsolete]
    public void OnInteraction(){
        this.gameObject.SetActive(false);
        OutdoorGameState.Instance.hasAxe = true;
        Debug.Log("This is axe !!!!!");
    }
}
