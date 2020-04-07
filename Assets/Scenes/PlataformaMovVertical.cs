using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovVertical : MonoBehaviour
{
    int dir;
    public int speed=50;
    public int bandera = 8;


    void Update()               //MOVIMIENTO CONTINUO DE LA PLATAFORMA DE FORMA VERTICAL  
    {
        if (transform.position.y >-3.4 || bandera>10){     //DEPENDIENDO DE LAS DIMENSIONES DE NUESTRO CAMPO EL -3.5, -3.4 Y 4.1 SE CAMBIAN
            dir = -2;
        }
        if(transform.position.y< -3.5){
            bandera=-10;                    //LAS BANDERAS SON SIMPLE CONTROL EL VALOR NO IMPORTA
        }
        if(transform.position.y> 4.1){                      
            bandera=11;
        }
        if(bandera<-9 ){
            dir = 2;
        }
        transform.Translate( 0,Time.deltaTime * dir * speed,0);
    }
}