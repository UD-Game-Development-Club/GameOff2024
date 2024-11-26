using UnityEngine;

public class AxeDeleteScript : MonoBehaviour, IInteractable
{
    [SerializeField] private OutdoorGameState outdoorGameState;
    public void OnInteraction()
    {
        outdoorGameState.HasAxe = true;
        gameObject.SetActive(false);
    }
}