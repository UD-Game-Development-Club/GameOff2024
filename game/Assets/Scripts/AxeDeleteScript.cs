using UnityEngine;

public class AxeDeleteScript : MonoBehaviour
{
    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        // Check the game state variable
        if (OutdoorGameState.Instance.hasAxe)
        {
            // Destroy this GameObject
            this.gameObject.SetActive(false);
        }
    }
}
