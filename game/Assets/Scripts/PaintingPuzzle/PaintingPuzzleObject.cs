using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PaintingPuzzleObject : MonoBehaviour
{
    [SerializeField] private PaintingPuzzleScore paintingPuzzleScore;
    private void Start()
    {
        paintingPuzzleScore = gameObject.AddComponent<PaintingPuzzleScore>();
    }

}
