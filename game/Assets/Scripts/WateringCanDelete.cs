using UnityEngine;

public class WateringCanDelete : MonoBehaviour, IInteractable
{
    [SerializeField] private OutdoorGameState outdoorGameState;
    public void OnInteraction()
    {
        outdoorGameState.HasCan = true;
        gameObject.SetActive(false);
    }
}