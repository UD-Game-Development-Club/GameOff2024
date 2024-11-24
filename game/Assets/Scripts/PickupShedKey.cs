using UnityEngine;

public class PickupShedKey : MonoBehaviour, IInteractable
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private DoorTrigger doorTrigger;

    [SerializeField] private AudioClip obtainSound;
    private PickUpController pickUpController;

    private void Start()
    {
        doorTrigger = Camera.main.GetComponent<DoorTrigger>();
        pickUpController = Camera.main.GetComponent<PickUpController>();
    }


    public void OnInteraction()
    {
        Debug.Log("Called interaction");
        doorTrigger.isUnlocked = true;
        Destroy(gameObject);

        // add an audio source to the player and make it play the obtain sound

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        AudioSource audioSource = player.AddComponent<AudioSource>();
        audioSource.clip = obtainSound;
        audioSource.Play();

        pickUpController.PickUpObject(gameObject);

        DialogueManager.Instance.StartDialogue(inkJSON);
    }
}
