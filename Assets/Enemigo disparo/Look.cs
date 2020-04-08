using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        //Voltear a ver algo
        transform.LookAt(target);

        //Mover en dirección adelante
        //transform.Translate(transform.forward*1*Time.deltaTime,Space.World);
    }
}
