using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene(1);
    }

    public void TryAgain(){
        print("HEY");
        SceneManager.LoadScene(0);
    }

    public void Quit(){
         Application.Quit();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(2);
        }
    }
}