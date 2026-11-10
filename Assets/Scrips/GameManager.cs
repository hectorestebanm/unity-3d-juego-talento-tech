using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        PlayerDelegate player = FindObjectOfType<PlayerDelegate>();
        if (player != null)
        {
            player.OnItemCollected += MostrarMensaje;
        }
    }

    private void MostrarMensaje(string itemName)
    {
        Debug.Log($"¡Recolectaste: {itemName}!");
    }
}