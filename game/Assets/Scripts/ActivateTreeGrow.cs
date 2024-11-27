using UnityEngine;

public class ActivateTreeGrow : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private OutdoorGameState outdoorGameState;

    // private void Update()
    // {
    //     if (outdoorGameState.TreeWatered && 
    //         targetObject != null && 
    //         !targetObject.activeSelf)
    //     {
    //         targetObject.SetActive(true);
    //         Debug.Log("Tree Grown in Present");
    //     }
    // }
}