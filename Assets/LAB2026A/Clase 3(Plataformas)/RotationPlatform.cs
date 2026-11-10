using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    void Update()
    {
        transform.Rotate(0, speed, 0);
    }

}
