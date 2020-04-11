using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaHorizontal : MonoBehaviour
{
    public int speed=1;
    public bool bandera = true;//true = derecha
    public int tilesToMove = 1;
    private float startingPositionX,rightBounds,leftBounds;

    private void Start()
    {
        startingPositionX = transform.position.x;
        rightBounds = startingPositionX + tilesToMove;
        leftBounds = startingPositionX - tilesToMove;
    }

    void Update()           //MOVIMIENTO CONTINUO DE LA PLATAFORMA DE FORMA HORIZONTAL
    {
        if (rightBounds - transform.position.x <0.01f)
        {
            speed *= -1;
        }

        if (transform.position.x - leftBounds <0.01f)
        {
            speed *= -1;
        }

        transform.Translate( Time.deltaTime * speed,0,0);
    }

}
