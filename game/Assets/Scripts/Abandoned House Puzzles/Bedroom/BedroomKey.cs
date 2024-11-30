using UnityEngine;

public class BedroomKey : MonoBehaviour, IInteractable
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public BedroomDoorTrigger doorTrigger;

    [SerializeField] private AudioClip obtainSound;
    private PickUpController pickUpController;

    private void Start()
    {
        pickUpController = Camera.main.GetComponent<PickUpController>();
    }

    public void OnInteraction()
    {
        doorTrigger.isUnlocked = true;
        Destroy(gameObject);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        AudioSource audioSource = player.AddComponent<AudioSource>();
        audioSource.clip = obtainSound;
        audioSource.Play();

        pickUpController.PickUpObject(gameObject);

        DialogueManager.Instance.StartDialogue(inkJSON);
    }
}
