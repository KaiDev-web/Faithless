using UnityEngine;
using UnityEngine.UI;

public class Guardian_Health : MonoBehaviour
{
    public float saluteMassima = 10000f;
    public float saluteAttuale;
    public Slider sd;
    int quantita;
    public Guardian_AI scriptIA;

    void Start()
    {
        saluteAttuale = saluteMassima;
        sd.maxValue = saluteMassima;
    }

    public void PrendiDanno(float danno)
    {
        saluteAttuale -= danno;
        {
            sd.value = saluteAttuale;
        }

        if(saluteAttuale <= 0)
        {
            Destroy(gameObject);
        }

        if(saluteAttuale == saluteMassima / 2)
        {
            scriptIA.velocita = 10f;
        }
    }

}
