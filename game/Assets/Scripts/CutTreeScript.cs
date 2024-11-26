using UnityEngine;

public class CutTreeScript : MonoBehaviour
{
    public void OnInteraction()
    {
        if (OutdoorGameState.Instance.HasAxe)
        {
            gameObject.SetActive(false);
            OutdoorGameState.Instance.TreeCut = true;
            // TODO: implement animation to cut down tree
            Debug.Log("Cut down tree");
        }
        else
        {
            // TODO: implement dialogue system to output hint
            Debug.Log("I need an axe");
        }
    }
}