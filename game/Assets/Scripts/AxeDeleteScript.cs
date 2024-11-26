using UnityEngine;

public class AxeDeleteScript : MonoBehaviour
{
    private void Update()
    {
        if (OutdoorGameState.Instance.HasAxe)
        {
            gameObject.SetActive(false);
        }
    }
}