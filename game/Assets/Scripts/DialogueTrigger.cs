using System;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
             DialogueManager.Instance.StartDialogue(inkJSON);

            // delete the current game object
            Destroy(gameObject);
        }
    }
}
