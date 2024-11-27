using UnityEngine;

public class OnWaterTreeRemove : MonoBehaviour
{
    [SerializeField] private OutdoorGameState outdoorGameState;
    private void Update()
    {
        if (outdoorGameState.TreeWatered)
        {
            gameObject.SetActive(false);
        }
    }
}