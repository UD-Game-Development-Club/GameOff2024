using UnityEngine;

public class WaterTreeScript : MonoBehaviour, IInteractable
{
    [SerializeField] private OutdoorGameState outdoorGameState;

    public void OnInteraction()
    {
        if (outdoorGameState.HasCan)
        {
            // TODO: implement animation to water tree
            outdoorGameState.TreeWatered = true;
        }
        else
        {
            // TODO: implement dialogue system to output hint
            Debug.Log("I need a watering can");
        }
    }
}