using UnityEngine;

public class OutdoorGameState : MonoBehaviour
{
    private static OutdoorGameState _instance;

    [System.Obsolete]
    public static OutdoorGameState Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<OutdoorGameState>();
                if (_instance == null)
                {
                    Debug.LogError("No GameState instance found in the scene!");
                }
            }
            return _instance;
        }
    }
private bool _hasAxe = false;
     public bool hasAxe
    {
        get { return _hasAxe; }
        set
        {
            _hasAxe = value;
            
        }
    }

    private bool _hasKey = false;
     public bool hasKey
    {
        get { return _hasKey; }
        set
        {
            _hasKey = value;
            
        }
    }

    private bool _treeCut = false;
    public bool treeCut
    {
        get { return _treeCut; }
        set
        {
            _treeCut = value;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes if necessary
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }
}
