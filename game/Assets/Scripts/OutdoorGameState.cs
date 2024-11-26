using UnityEngine;

public class OutdoorGameState : MonoBehaviour
{
    public static OutdoorGameState Instance { get; private set; }

    public bool HasAxe { get; set; } = false;
    public bool HasCan { get; set; } = false;
    public bool TreeCut { get; set; }
    public bool TreeWatered { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}