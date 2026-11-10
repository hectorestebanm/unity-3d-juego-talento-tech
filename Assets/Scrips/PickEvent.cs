using UnityEngine;

public class PickEvent : MonoBehaviour
{
    [SerializeField] private AudioClip pickSound;
    [SerializeField, Range(0f, 1f)] private float volume = 1f;
    private string name1;
    private int value = 5;
    public delegate void Format1(string item, int value);
    public static event Format1 myPickEvent;
    void Start()
    {
        // Obtengo el nombre de la moneda
        name1 = gameObject.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FuiAgarrado(name1);
        }
    }
    private void FuiAgarrado(string a)
    {
        if (myPickEvent != null)
        {
            myPickEvent.Invoke(name1, value);
            Debug.Log($"Soy {name1} y me agarraron");
            if(pickSound != null)
            {
                AudioSource.PlayClipAtPoint(pickSound, transform.position, volume);
            }
            Destroy(gameObject, 0.1f);
        }
    }
}
