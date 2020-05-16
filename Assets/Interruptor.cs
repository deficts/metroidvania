using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    public GameObject plataforma;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        plataforma.SetActive(true);
        GetComponent<SpriteRenderer>().color = new Color(0.3235289f, 1f, 0.2235294f);
    }
}
