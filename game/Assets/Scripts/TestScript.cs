using UnityEngine;

public class TestScript : MonoBehaviour, IInteractable
{
    public void OnInteraction()
    {
        Debug.Log("this works");
        gameObject.SetActive(false);
    }
}
