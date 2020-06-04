using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image Bar;
    public PlayerManager player;
    private int vidaBarra;
    
    // Start is called before the first frame update
    void Start()
    {
        vidaBarra=player.vida/100;
    }

    // Update is called once per frame
    void Update()
    {
        vidaBarra=player.vida/100;
        Bar.fillAmount=vidaBarra;
    }
}
