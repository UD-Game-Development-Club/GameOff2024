using Unity.VisualScripting;
using UnityEngine;

public class CutTreeScript : MonoBehaviour, IInteractable
{
    [System.Obsolete]
    public void OnInteraction(){
        if(OutdoorGameState.Instance.hasAxe){
            this.gameObject.SetActive(false);
            OutdoorGameState.Instance.treeCut = true;
            // TODO: implement animation to cut down tree
            Debug.Log("Chopped down tree");
        }
        else{
            // TODO: implement dialogue system to output hint
            Debug.Log("I need an axe to cut this down");
        }
    }
}
