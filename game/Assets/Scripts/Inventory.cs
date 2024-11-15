using UnityEngine;
using System.Collections.Generic;
public class Inventory : MonoBehaviour
{
    private HashSet<string> inventory = new HashSet<string>();
    public event System.Action<string> OnKeyAdded;

    public void AddKey(string keyID)
    {
        if (string.IsNullOrEmpty(keyID)) return;

        inventory.Add(keyID);
        OnKeyAdded?.Invoke(keyID);
        Debug.Log($"Added {keyID} to inventory");
    }

    public bool HasKey(string keyID)
    {
        return !string.IsNullOrEmpty(keyID) && inventory.Contains(keyID);
    }

    public bool RemoveKey(string keyID)
    {
        return inventory.Remove(keyID);
    }
}