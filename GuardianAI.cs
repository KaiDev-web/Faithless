using JetBrains.Annotations;
using UnityEngine;

public class Guardian_AI : MonoBehaviour
{
    public enum StatoBoss { inattivo, inseguimento, attacco };
    public StatoBoss StatoAttuale;
    
    public Transform giocatore;
    public float TempoProssimoAttacco;
    public float IntervalloAttacchi;
    public float distanzaAttacco;
    float distanza;
    public Rigidbody2D rb;
    public float velocita = 6;

    void Start()
    {
        
    }

    void Update()
    {
        distanza = Vector2.Distance(transform.position, giocatore.position);

        switch(StatoAttuale)
        {
            case StatoBoss.inattivo:
            
            if(distanza < 8)
                {
                   StatoAttuale = StatoBoss.inseguimento;
                }
            break;

            case StatoBoss.inseguimento:

            transform.position = Vector2.MoveTowards(transform.position, giocatore.position, velocita * Time.deltaTime);

            if(distanza < distanzaAttacco)
                {
                    StatoAttuale = StatoBoss.attacco;
                }
            break;

            case StatoBoss.attacco:

            if(Time.time >= TempoProssimoAttacco)
                {
                    TempoProssimoAttacco = Time.time + IntervalloAttacchi;
                    EseguiAttacco();
                }
            
            if(distanza > 8)
                {
                    StatoAttuale = StatoBoss.inseguimento;
                }
            break;

        }

        if(giocatore.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }

    public void EseguiAttacco()
    {
        
    }

}
