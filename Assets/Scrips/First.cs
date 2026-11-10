using UnityEngine;
using UnityEngine.InputSystem;

public class First : MonoBehaviour
{
    private Transform p;
    public float sensitivity = 100f;
    private float xRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p = GameObject.FindWithTag("Heroe").GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseInput = Mouse.current.delta.ReadValue();
        xRotation -= mouseInput.y * sensitivity * 0.01f;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //p.Rotate(Vector3.up * mouseInput.x);
        p.Rotate(Vector3.up * mouseInput.x * sensitivity * 0.01f);
    }
}
