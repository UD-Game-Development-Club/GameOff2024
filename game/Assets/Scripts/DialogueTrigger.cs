using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Game Input")]
    [SerializeField] private GameInput input;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private bool playerInRange;
    private void Awake() {
    }

    // Update is called once per frame
    void Update()
    {
        if (input.GetInteractClick() && playerInRange)
        {
            Debug.Log(inkJSON);
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider) 
    {
        if(collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
