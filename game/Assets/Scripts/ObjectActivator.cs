using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    // Reference to the object that may become inactive
    public GameObject targetObject;

    [System.Obsolete]
    void Update()
    {
        // Example: Reactivate the object when the "R" key is pressed
        if (OutdoorGameState.Instance.treeCut)
        {
            // Check if the target object exists
            if (targetObject != null && !targetObject.activeSelf)
            {
                // Reactivate the object
                targetObject.SetActive(true);
                Debug.Log("Target object reactivated!");
            }
        }
    }
}

