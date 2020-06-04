using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botellas : MonoBehaviour
{
    public Sprite[] botellas;
    
    // Start is called before the first frame update
    void Start()
    {
        cambioBotella(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambioBotella(int b){
        this.GetComponent<Image>().sprite=botellas[b];
    }
}
