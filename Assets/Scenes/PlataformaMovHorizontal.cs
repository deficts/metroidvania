using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovHorizontal : MonoBehaviour
{
    int dir;
    public int speed=1;
    public int bandera = 8;
    
    void Update()           //MOVIMIENTO CONTINUO DE LA PLATAFORMA DE FORMA HORIZONTAL
    {
        if (transform.position.x >-8.6 || bandera>10){      //DEPENDIENDO DE LAS DIMENSIONES DE NUESTRO CAMPO EL -8.5, -8.6 Y 7.5 SE CAMBIAN
            dir = -2;
        }
        if(transform.position.x< -8.5){
            bandera=-10;
        }
        if(transform.position.x> 7.5){          //LAS BANDERAS SON SIMPLE CONTROL EL VALOR NO IMPORTA
            bandera=11;
        }
        if(bandera<-9 ){
            dir = 2;
        }
        transform.Translate( Time.deltaTime * dir * speed,0,0);
    }
}
