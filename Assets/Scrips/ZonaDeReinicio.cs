using UnityEngine;
using UnityEngine.SceneManagement;

public class ZonaDeReinicio : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
