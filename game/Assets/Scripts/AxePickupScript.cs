using Unity.VisualScripting;
using UnityEngine;

public class AxePickupScript : MonoBehaviour, IInteractable
{
    public void OnInteraction(){
        gameObject.SetActive(false);
        Debug.Log("This is axe !!!!!");
    }
}
