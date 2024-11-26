using UnityEngine;

public class ActivateTreeGrow : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    private void Update()
    {
        if (OutdoorGameState.Instance.TreeWatered && 
            targetObject != null && 
            !targetObject.activeSelf)
        {
            targetObject.SetActive(true);
            Debug.Log("Tree Grown in Present");
        }
    }
}