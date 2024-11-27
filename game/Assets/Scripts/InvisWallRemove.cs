using UnityEngine;

public class InvisWallRemove : MonoBehaviour
{
    [SerializeField] private OutdoorGameState outdoorGameState;
    private void Update() {
        if (outdoorGameState.TreeCut) gameObject.SetActive(false);
    }

}
