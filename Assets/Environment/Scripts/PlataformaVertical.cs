using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    public int speed=1;
    public bool bandera = true; //true = arriba
    public int tilesToMove=1;
    private float startingPositionY, upperBounds, lowerBounds;


    private void Start()
    {
        startingPositionY = transform.position.y;
        upperBounds = startingPositionY + tilesToMove;
        lowerBounds = startingPositionY - tilesToMove;
    }

    void Update()               //MOVIMIENTO CONTINUO DE LA PLATAFORMA DE FORMA VERTICAL  
    {

        if (transform.position.y > upperBounds)
        {
            speed *= -1;
        }

        if (transform.position.y < lowerBounds)
        {
            speed *= -1;
        }


        transform.Translate( 0,Time.deltaTime * speed,0);
    }
}