using UnityEngine;

public class PlayerDelegate : MonoBehaviour
{
    public delegate void ItemCollectedDelegate(string itemName);
    public event ItemCollectedDelegate OnItemCollected;

    public void CollectItem(string itemName)
    {
        Debug.Log($"Collected: {itemName}");
        OnItemCollected?.Invoke(itemName);
    }
}
