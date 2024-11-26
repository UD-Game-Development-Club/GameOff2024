using UnityEngine;

public class OnWaterTreeRemove : MonoBehaviour
{
    private void Update()
    {
        if (OutdoorGameState.Instance.TreeWatered)
        {
            gameObject.SetActive(false);
        }
    }
}