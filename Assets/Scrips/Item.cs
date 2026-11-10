using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName = "Moneda";

    private void OnTriggerEnter(Collider other)
    {
        PlayerDelegate player = other.GetComponent<PlayerDelegate>();
        if (player != null)
        {
            player.CollectItem(itemName);
            Destroy(gameObject);
        }
    }
}