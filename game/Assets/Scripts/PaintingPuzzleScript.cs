using System.Data.Common;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaintingPuzzleScript : MonoBehaviour
{
    public GameObject painting;
    public Transform dropLocation;
    private bool isHoldingPainting = false;

    private void OnSceneEnter()
    {
        while (SceneManager.GetActiveScene().name == "hauntedHouse")
        {
            if (isHoldingPainting)
            {
                //get current painting
                //if (dropped)
                //{
                    isHoldingPainting = false;
                //}
            }
        }
    }
    public void OnCollisionEnter()
    {
        //when colliding with specific painting place
        //snap painting to that position
        //if it is the correct painting for that position
    }
    public void StartHoldingPainting()
    {
        isHoldingPainting = true;
    }
    public void StopHoldingPainting()
    {
        isHoldingPainting = false;
    }
}
