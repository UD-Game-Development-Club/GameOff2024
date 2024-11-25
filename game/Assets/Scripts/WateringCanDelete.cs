using UnityEngine;

public class WateringCanDelete : MonoBehaviour
{
    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        // Check the game state variable
        if (OutdoorGameState.Instance.hasCan)
        {
            // Destroy this GameObject
            this.gameObject.SetActive(false);
        }
    }
}
