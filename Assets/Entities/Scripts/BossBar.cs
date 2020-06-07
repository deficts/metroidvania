
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    // Start is called before the first frame update
  public Image Bar;
    public Boss boss;
    private float vidaBarra;
    
    // Start is called before the first frame update
    void Start()
    {
        vidaBarra=(float)boss.vida/100;
    }

    // Update is called once per frame
    void Update()
    {
        vidaBarra=(float)boss.vida/100;
        Bar.fillAmount=vidaBarra;
        
    }
}
