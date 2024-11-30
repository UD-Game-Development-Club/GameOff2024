using Unity.VisualScripting;
using UnityEngine;

public class WaterTreeScript : MonoBehaviour, IInteractable
{
    [System.Obsolete]
    public void OnInteraction(){
        if(OutdoorGameState.Instance.hasCan){
            this.gameObject.SetActive(false);
            OutdoorGameState.Instance.treeWatered = true;
            // TODO: implement animation to cut down tree
            Debug.Log("Watered Tree");
        }
        else{
            // TODO: implement dialogue system to output hint
            Debug.Log("I need a watering can");
        }
    }
}
