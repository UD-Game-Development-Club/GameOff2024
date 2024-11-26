using UnityEngine;

public class ActivateTreeBridge : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    private void Update()
    {
        if (OutdoorGameState.Instance.TreeCut && 
            targetObject != null && 
            !targetObject.activeSelf)
        {
            targetObject.SetActive(true);
            Debug.Log("Tree Bridge Activated");
        }
    }
}