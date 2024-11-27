using UnityEngine;

public class RemovePresentSapling : MonoBehaviour
{
    [SerializeField] private OutdoorGameState outdoorGameState;
    private void Update() {
        if (outdoorGameState.TreeWatered) gameObject.SetActive(false);
    }
}
