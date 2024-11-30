using UnityEngine;

public class OutroCutsceneController : MonoBehaviour
{
    /*
     * End slideshow
     */
    private GameInput gameInput;
    private GameObject slide;
    [SerializeField] private Texture2D[] slides;
    private int slideIndex = 0;

    /*
     * Credits
     */
    [SerializeField] private GameObject credits;
    private int creditThresh = 5000;

    // common
    private bool inSlideShow = true;


    void Start()
    {
        gameInput = gameObject.AddComponent<GameInput>();
        slide = transform.Find("CurrentSlide").gameObject;
    }

    void Update()
    {
        if(inSlideShow)
        {
            slide.GetComponent<UnityEngine.UI.RawImage>().texture = slides[slideIndex];

            if (gameInput.GetSpaceBar())
            {
                slideIndex++;

                if (slideIndex >= slides.Length)
                {
                    inSlideShow = false;
                    transform.Find("CurrentSlide").gameObject.SetActive(false);
                    transform.Find("proceed").gameObject.SetActive(false);
                }
            }
        }
        else
        {
            // slide the credits upwards to simulate scrolling
            credits.transform.position += new Vector3(0, 100 * Time.deltaTime, 0);

            // leaving this because of a weird bug, i will need to use it later LOL
            //Debug.Log(credits.transform.position.y);
            if(credits.transform.position.y > creditThresh)
                UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
        }
    }
}
