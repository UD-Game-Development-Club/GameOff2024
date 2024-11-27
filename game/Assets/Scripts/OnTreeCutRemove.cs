using UnityEngine;

public class OnTreeCutRemove : MonoBehaviour, IInteractable
{
    [SerializeField] private OutdoorGameState outdoorGameState;
    private void Update() {
        Debug.Log("outdoorGameState.TreeWatered: " + outdoorGameState.TreeWatered);
        if (outdoorGameState.TreeWatered) gameObject.SetActive(true);
    }
    public void OnInteraction() {
        if (outdoorGameState.HasAxe) {
            gameObject.SetActive(false);
            outdoorGameState.TreeCut = true;
        } else {
            // TODO: Add animation
            Debug.Log("Need Axe");
        }
    }
}