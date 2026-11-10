using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryZone : MonoBehaviour
{
    [SerializeField] private GameObject panelVictoria;
    private bool gano = false;

    void Start()
    {
        // Por si venís de una partida anterior que quedó pausada
        // Reinicia el juego a su velocidad normal
        // 1 velocidad normal. 0 El juego se congela
        Time.timeScale = 1f;
        panelVictoria.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (gano || !other.CompareTag("Player")) return;

        gano = true;
        panelVictoria.SetActive(true);
        Time.timeScale = 0f; // congela el juego
        // Libera el mouse para poder usarlo en la pantalla de victoria
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Se asignan desde los botones
    public void VolverAJugar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuInicio");
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}