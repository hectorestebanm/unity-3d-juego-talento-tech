using UnityEngine;

public class PlayerPickEvent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PickEvent.myPickEvent += PickedUp;
    }

    private void PickedUp(string item, int value)
    {
        Debug.Log($"Agarre {item} chaval. Junte {value} de oro");
    }
}
