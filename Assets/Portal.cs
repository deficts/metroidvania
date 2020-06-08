using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public enum nivel
    {
        boss,
        second
    }

    public nivel currentNivel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerManager.botellas==6 && currentNivel==nivel.second)
        {
            SceneManager.LoadScene("FinalBoss");
        }

        if (collision.gameObject.CompareTag("Player") && currentNivel == nivel.boss)
        {
            SceneManager.LoadScene("End");
        }
    }
}
