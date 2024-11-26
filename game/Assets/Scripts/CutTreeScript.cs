using UnityEngine;

public class CutTreeScript : MonoBehaviour
{
    [System.Obsolete]
    public void OnInteraction(){
        if(OutdoorGameState.Instance.hasAxe){
            this.gameObject.SetActive(false);
            OutdoorGameState.Instance.treeCut = true;
            // TODO: implement animation to cut down tree
            Debug.Log("Cut down tree");
        }
        else{
            // TODO: implement dialogue system to output hint
            Debug.Log("I need an axe");
        }
    }
}
