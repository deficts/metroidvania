using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image Bar;
    public PlayerManager player;
    private float vidaBarra;
    
    // Start is called before the first frame update
    void Start()
    {
        vidaBarra=(float)player.vida/100;
    }

    // Update is called once per frame
    void Update()
    {
        vidaBarra=(float)player.vida/100;
        Bar.fillAmount=vidaBarra;
    }
}
