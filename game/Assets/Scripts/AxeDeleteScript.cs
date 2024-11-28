using UnityEngine;

public class AxeDeleteScript : MonoBehaviour, IInteractable
{
    public void OnInteraction()
    {
        OutdoorGameState.Instance.hasAxe = true;
        gameObject.SetActive(false);
    }
}