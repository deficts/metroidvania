using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPerrito : MonoBehaviour
{
    public GameObject proyectil;
    public Transform firePoint, firePointUp, firePointDown;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKeyUp(KeyCode.X))
            {
                Disparar(firePointUp);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKeyUp(KeyCode.X))
            {
                Disparar(firePointDown);
            }
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            Disparar(firePoint);
        }
    }

 
    void Disparar(Transform fP)
    {
        Instantiate(proyectil, fP.position, fP.rotation);
    }
}
