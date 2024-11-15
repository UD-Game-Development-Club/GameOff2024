using UnityEngine;
using UnityEngine.Audio;

public class FootstepController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private AudioClip[] woodFootstepSounds;
    [SerializeField] private AudioClip[] concreteFootstepSounds;
    [SerializeField] private AudioClip[] carpetFootstepSounds;
    [SerializeField] private AudioClip[] grassFootstepSounds;

    public float footstepInterval = .8f;
    public float footstepCooldown = 0f;
    public float footstepPitchVariance = 0.1f;
    public float cooldownVariance = 0.1f;

    // created in Start(), used for footstep sounds
    private AudioSource audioSource;

    /*
     * Takes in a downwards raycast result and plays a footstep
     * sound based on the tag of the object beneath the player
     */
    public void PlayFootstepSound(RaycastHit hit) {
        switch (hit.collider.tag)
        {
            case "wood":
                audioSource.clip = woodFootstepSounds[Random.Range(0, woodFootstepSounds.Length)];
                break;
            case "carpet":
                audioSource.clip = carpetFootstepSounds[Random.Range(0, carpetFootstepSounds.Length)];
                break;
            case "grass":
                audioSource.clip = grassFootstepSounds[Random.Range(0, grassFootstepSounds.Length)];
                break;
            default:
            case "concrete":
                audioSource.clip = concreteFootstepSounds[Random.Range(0, concreteFootstepSounds.Length)];
                break;
        }
        // add extra "unique-ness" to the footstep sound
        audioSource.pitch = 1f + Random.Range(-footstepPitchVariance, footstepPitchVariance);
        audioSource.Play();
        footstepCooldown = footstepInterval + Random.Range(-cooldownVariance, cooldownVariance);
    }

    void Start()
    {
        // audio source for the footstep sounds
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        //audioSource.volume = .5f;
        audioSource.loop = false;
    }

    void Update()
    {
        footstepCooldown -= Time.deltaTime;
    }
}
