using UnityEngine;

public class OnTreeCutRemove : MonoBehaviour, IInteractable
{
    [SerializeField] private OutdoorGameState outdoorGameState;
    [SerializeField] private GameObject invisWall1;
    [SerializeField] private GameObject invisWall2;
    
    public void OnInteraction() {
        if (outdoorGameState.hasAxe) {
            gameObject.SetActive(false);
            invisWall1.SetActive(false);
            invisWall2.SetActive(false);
            outdoorGameState.treeCut = true;
        } else {
            // TODO: Add animation
            Debug.Log("Need Axe");
        }
    }
}