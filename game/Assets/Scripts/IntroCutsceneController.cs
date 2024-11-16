using UnityEngine;

public class IntroCutsceneController : MonoBehaviour
{
    private GameObject slide;

    public int slideIndex = 0;

    [SerializeField] private Texture2D[] slides;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slide = transform.Find("CurrentSlide").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        slide.GetComponent<UnityEngine.UI.RawImage>().texture = slides[slideIndex];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            slideIndex++;
        
            if(slideIndex >= slides.Length)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("basement");
            }
        }
    }
}
