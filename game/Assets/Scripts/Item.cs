using UnityEngine;
public interface Item
{
    string ItemID { get; }
    void OnPickup(Inventory inventory);
}