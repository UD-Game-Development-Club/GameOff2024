using UnityEngine;
public class KeyItem : MonoBehaviour, IInteractable
{
    [SerializeField] private readonly string itemID = "Example Key";
    //[SerializeField] private AudioClip pickupSound;
    //[SerializeField] private GameObject pickupEffect;

    public string ItemID => itemID;

    public void OnPickup(Inventory inventory)
    {
        if (inventory == null) return;

        //if (pickupSound != null)
        //{
        //    AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        //}
        //if (pickupEffect != null)
        //{
        //    Instantiate(pickupEffect, transform.position, Quaternion.identity);
        //}

        inventory.AddKey(itemID);
        Debug.Log($"Picked up key: {itemID}");
        Destroy(gameObject);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        var inventory = other.GetComponent<Inventory>();
    //        if (inventory != null)
    //        {
    //            OnPickup(inventory);
    //        }
    //    }
    //}

    public void Interact()
    {
        Debug.Log(Random.Range(0, 100));
    }
}