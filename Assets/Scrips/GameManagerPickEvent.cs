using UnityEngine;

public class GameManagerPickEvent : MonoBehaviour
{
    private int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PickEvent.myPickEvent += AddScore;
    }

    private void AddScore(string item, int value)
    {
        score += value;
        Debug.Log($"Mi puntaje ahora es de {score}");
    }
}
