using UnityEngine;

public class PaintingPuzzleScore : MonoBehaviour
{
    private GameObject painting;
    private Rigidbody rb;
    private BoxCollider boxCollider;
    private static int puzzleScore = 0;
    [SerializeField] private string[] Tags;  // Tags to check for collision

    private void Start()
    {
        painting = gameObject;  // Store the reference to the GameObject this script is attached to
        rb = GetComponent<Rigidbody>(); // Store reference to GameObjects RigidBody
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (string tag in Tags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                // Snap in place
                painting.transform.position = collision.gameObject.transform.position;
                painting.transform.rotation = collision.gameObject.transform.rotation;
                // stop rigidbody
                rb.isKinematic = true;
                // stop collider
                boxCollider.enabled = false;

                // Puzzle score +1
                puzzleScore++;

                // Display the updated score in the console
                Debug.Log("Puzzle Score: " + puzzleScore);

                // Check if the puzzle is complete
                if (puzzleScore == 3)
                {
                    // TODO: Finish puzzle action (e.g., play animation, unlock something, etc.)
                    Debug.Log("Puzzle Complete!");
                    // Play finish animation or trigger some action
                }

                return;  // Exit after the first valid collision to avoid multiple triggers
            }
        }
    }
}
