using UnityEngine;

public class IntroCutsceneController : MonoBehaviour
{
    private GameInput gameInput;

    private GameObject slide;
    [SerializeField] private Texture2D[] slides;
    private int slideIndex = 0;

    void Start()
    {
        gameInput = gameObject.AddComponent<GameInput>();
        slide = transform.Find("CurrentSlide").gameObject;
    }

    void Update()
    {
        slide.GetComponent<UnityEngine.UI.RawImage>().texture = slides[slideIndex];

        if (gameInput.GetSpaceBar())
        {
            slideIndex++;
        
            if(slideIndex >= slides.Length)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("basement");
            }
        }
    }
}
