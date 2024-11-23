using UnityEngine;

public class OnTreeCut : MonoBehaviour
{
    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(OutdoorGameState.Instance.treeCut){
            // Destroy this GameObject
            this.gameObject.SetActive(false);
        }
    }
}
