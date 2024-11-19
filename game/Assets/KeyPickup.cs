using UnityEngine;

public class KeyPickup : MonoBehaviour, IInteractable
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public StairTrigger stairTrigger;

    [SerializeField] private AudioClip obtainSound;

    public void OnInteraction()
    {
        stairTrigger.isUnlocked = true;
        Destroy(gameObject);

        // add an audio source to the player and make it play the obtain sound

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        AudioSource audioSource = player.AddComponent<AudioSource>();
        audioSource.clip = obtainSound;
        audioSource.Play();

        DialogueManager.Instance.StartDialogue(inkJSON);
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);
    }
}
