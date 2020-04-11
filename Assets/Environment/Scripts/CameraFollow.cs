using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform personaje;
    public float dampTime = 0.4f;
    public int yOffset = 2;
    private Vector3 cameraPos;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        cameraPos = new Vector3(personaje.position.x, personaje.position.y+yOffset, -10f);
        transform.position = Vector3.SmoothDamp(transform.position, cameraPos, ref velocity, dampTime);
    }
}
