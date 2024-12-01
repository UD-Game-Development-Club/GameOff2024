using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterReset : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("somting entered water");
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player entered water");
            //other.transform.position = new Vector3(-257.02f, 0f, -217.6f);

            // get object named "Sapling Present" and move the player to it
            GameObject saplingPresent = GameObject.Find("Tiny Rock 3");
            other.transform.position = saplingPresent.transform.position;
        }
    }
}
