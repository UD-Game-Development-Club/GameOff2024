using UnityEngine;

public class OnTreeCut : MonoBehaviour
{
    public OutdoorGameState outdoorGameState;
    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(outdoorGameState.treeCut){
            // Destroy this GameObject
            this.gameObject.SetActive(false);
        }
    }
}
