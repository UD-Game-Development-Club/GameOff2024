using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    public int choiceIndex;
    public void OnButtonClick()
    {
        DialogueManager.Instance.MakeChoice(choiceIndex);
    }
}
