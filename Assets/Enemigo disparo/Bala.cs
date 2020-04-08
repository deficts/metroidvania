using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        Rigidbody[] rbs=GetComponents<Rigidbody>();
        rb.AddForce(transform.up*11,ForceMode.Impulse);
        Destroy(gameObject,3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
