using UnityEngine;

public class WateringCanDelete : MonoBehaviour
{
    private void Update()
    {
        if (!OutdoorGameState.Instance.HasCan)
        {
            gameObject.SetActive(false);
        }
    }
}