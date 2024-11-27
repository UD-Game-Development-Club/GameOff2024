using UnityEngine;

public class TreeIsCut : MonoBehaviour
{
    [SerializeField] private OutdoorGameState outdoorGameState;
    private void Update() {
        if (outdoorGameState.TreeCut) gameObject.SetActive(true);
    }

}
