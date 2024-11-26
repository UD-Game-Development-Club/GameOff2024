using UnityEngine;

public class OnTreeCut : MonoBehaviour
{
    private void Update()
    {
        if (OutdoorGameState.Instance.TreeCut)
        {
            gameObject.SetActive(false);
        }
    }
}