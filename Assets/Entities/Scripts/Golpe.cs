using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Golpe : MonoBehaviour
{
    public float vida=100.0f;
    public GameObject player;
    public Image damage;
    public float flash=10f;
    public Color fColor=new Color(1f,0f,0f,0.1f);
    bool damaged;

    // Start is called before the first frame update
    void Start()
    {
        Ataque();
        damage.color=Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetKeyDown(KeyCode.G)){
           Ataque();
        }
       
    }

    void Ataque(){
        if(Vector3.Distance(player.transform.position,transform.position)<0.3f){
            vida--;
            if(damaged){
            damage.color=fColor;
            }else{
            damage.color=Color.Lerp(damage.color,Color.clear,flash*Time.deltaTime);
            }
            damaged=false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Ataque();
    }
}
