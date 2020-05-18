using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene(1);
    }

    public void Quit(){
         Application.Quit();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(2);
    }
}