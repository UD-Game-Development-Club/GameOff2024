using UnityEngine;

public class SafeKeyPickup : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject door;

    public void OnInteraction()
    {
        door.GetComponent<SugarDoor>().unlocked = true;
        Destroy(gameObject);
    }
}
