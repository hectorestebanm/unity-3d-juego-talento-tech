using UnityEngine;

public class DelegateExample : MonoBehaviour
{
    private delegate void ActionDelegate();
    private ActionDelegate OnAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnAction = Jump;
        OnAction();
    }

    private void Jump()
    {
        Debug.Log("The Player jumps!");
    }
}
