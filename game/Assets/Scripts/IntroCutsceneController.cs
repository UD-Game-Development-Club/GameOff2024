using UnityEngine;

public class IntroCutsceneController : MonoBehaviour
{
    private GameInput gameInput;

    private GameObject slide;
    [SerializeField] private Texture2D[] slides;
    private int slideIndex = 0;

    private AudioSource src;
    [SerializeField] AudioClip slideSound;

    void Start()
    {
        gameInput = gameObject.AddComponent<GameInput>();
        slide = transform.Find("CurrentSlide").gameObject;
        src = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        slide.GetComponent<UnityEngine.UI.RawImage>().texture = slides[slideIndex];

        if (gameInput.GetSpaceBar())
        {
            slideIndex++;

            src.clip = slideSound;
            src.Play();

            if (slideIndex >= slides.Length)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("basement");
            }
        }
    }
}
