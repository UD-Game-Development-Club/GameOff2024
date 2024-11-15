using UnityEngine;
public class Door : MonoBehaviour
{
    [SerializeField] private string requiredKeyID = "Example Key";  // Specify which key opens this door
    //[SerializeField] private AudioClip openSound;
    //[SerializeField] private AudioClip lockedSound;
    private float openDelay = 0.5f;  // Delay before door destroys

    private Inventory inventory;
    private bool isOpen = false;

    private void Start()
    {
        // Better to assign in inspector, but this works as fallback
        if (inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isOpen) return;

        if (other.CompareTag("Player"))
        {
            if (inventory != null && inventory.HasKey(requiredKeyID))
            {
                OpenDoor();
            }
            else
            {
                // Play locked sound and show message
                //if (lockedSound != null)
                //{
                //    AudioSource.PlayClipAtPoint(lockedSound, transform.position);
                //}
                Debug.Log("This door is locked! Find the correct key.");
            }
        }
    }

    private void OpenDoor()
    {
        if (isOpen) return;

        isOpen = true;

        //if (openSound != null)
        //{
        //    AudioSource.PlayClipAtPoint(openSound, transform.position);
        //}

        Debug.Log($"Opening door with key: {requiredKeyID}");

        inventory.RemoveKey(requiredKeyID);

        Destroy(gameObject, openDelay);
    }
}