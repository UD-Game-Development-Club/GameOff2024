using UnityEngine;

public class OnWaterTreeRemove : MonoBehaviour
{
    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(OutdoorGameState.Instance.treeWatered){
            // Destroy this GameObject
            this.gameObject.SetActive(false);
        }
    }
}
