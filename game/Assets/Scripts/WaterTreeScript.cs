using UnityEngine;

public class WaterTreeScript : MonoBehaviour, IInteractable
{
    public void OnInteraction()
    {
        if (OutdoorGameState.Instance.HasCan)
        {
            gameObject.SetActive(false);
            OutdoorGameState.Instance.TreeWatered = true;
            // TODO: implement animation to water tree
            Debug.Log("Watered Tree");
        }
        else
        {
            // TODO: implement dialogue system to output hint
            Debug.Log("I need a watering can");
        }
    }
}