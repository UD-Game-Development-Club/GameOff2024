using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Whiteboard : DialogueInteract
{
    [SerializeField] private TextAsset boardJson;
    public override void OnInteraction()
    {
        DialogueManager.Instance.StartDialogue(inkJSON, OnEnd);
    }

    private void OnEnd()
    {
        SceneManager.LoadScene("EndCutscene", LoadSceneMode.Single);
    }
}
