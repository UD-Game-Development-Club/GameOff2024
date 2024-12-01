using UnityEngine;
using UnityEngine.Audio;

public class PaintingPuzzleScore : MonoBehaviour
{
    private GameObject painting;
    [SerializeField] private GameObject win;
    private Rigidbody rb;
    private BoxCollider boxCollider;
    public static int puzzleScore = 0;

    [SerializeField] private string[] CollideTags;  // Tags to check for collision
    [SerializeField] private string LightTag;
    private GameObject lightObject;

    [SerializeField] private AudioClip sound;
    private AudioSource audioSource;

    private void Start()
    {
        painting = gameObject;
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

        audioSource = painting.AddComponent<AudioSource>();
        audioSource.clip = sound;

        lightObject = GameObject.FindWithTag(LightTag);
        if (win != null)
        {
            win.gameObject.SetActive(false);
        }
        if (lightObject != null)
        {
            lightObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (puzzleScore == 3 && win != null && !win.gameObject.activeSelf)
        {
            win.gameObject.SetActive(true);
            audioSource.Play();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        foreach (string tag in CollideTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                painting.transform.position = collision.gameObject.transform.position;
                painting.transform.rotation = collision.gameObject.transform.rotation;

                rb.isKinematic = true;
                boxCollider.enabled = false;

                if (lightObject != null)
                {
                    lightObject.SetActive(true);
                }

                audioSource.Play();

                puzzleScore++;

                return;  // Exit after the first valid collision to avoid multiple triggers
            }
        }
    }
}
