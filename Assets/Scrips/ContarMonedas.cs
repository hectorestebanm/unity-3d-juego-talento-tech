using UnityEngine;
using TMPro;

public class ContarMonedas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoContador;
    [SerializeField] private int monedasMaximas = 2;
    private int monedasRecolectadas = 0;
    private void Start()
    {
        PickEvent.myPickEvent += SumarMoneda;
        ActualizarTexto();
    }

    private void SumarMoneda(string item, int value)
    {
        monedasRecolectadas++;
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        textoContador.text = $"Monedas: {monedasRecolectadas} / {monedasMaximas}";
    }

    private void OnDestroy()
    {
        PickEvent.myPickEvent -= SumarMoneda;
    }
}
