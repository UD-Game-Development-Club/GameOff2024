using UnityEngine;

public class ActivateTreeGrow : MonoBehaviour
{
    // Reference to the object that may become inactive
    [SerializeField] private GameObject targetObject;

    [System.Obsolete]
    void Update()
    {
        if (OutdoorGameState.Instance.treeWatered)
        {
            // Check if the target object exists
            if (targetObject != null && !targetObject.activeSelf)
            {
                // Reactivate the object
                targetObject.SetActive(true);
                Debug.Log("Tree Grown in Present");
            }
        }
    }
}

