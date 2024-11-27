using UnityEngine;

public class CutTreeScript : MonoBehaviour
{
    [SerializeField] private OutdoorGameState outdoorGameState;
    public void OnInteraction()
    {
        if (outdoorGameState.HasAxe)
        {
            gameObject.SetActive(false);
            outdoorGameState.TreeCut = true;
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