using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum statoNemico { inattivo, inseguimento, attacco };
    public statoNemico statoAttuale;

    public Transform giocatore;
    public float TempoProssimoAttacco;
    public float IntervalloAttacchi;
    public float distanzaAttacco;
    float distanza;
    public RigidBody2D rb;
    public float velocitaNemico = 4f;

    void Update()
    {
        distanza = Vector2.Distance(transform.position, giocatore.position);

        switch(statoAttuale)
        {
            case statoNemico.inattivo:

            if(distanza < 4)
                {
                    statoAttuale = statoNemico.inseguimento;
                    Debug.Log("Current Enemy State: Following.");
                }
            break;

            case statoNemico.inseguimento:
            
            transform.position = Vector2.MoveTowards(transform.position, giocatore.position, velocitaNemico * Time.deltaTime);

            if(distanza < distanzaAttacco)
                {
                    statoAttuale = statoNemico.attacco;
                    Debug.Log("Current Enemy State: Attack.");
                }
            break;

            case statoNemico.attacco:

            if(Time.time >= TempoProssimoAttacco)
                {
                    TempoProssimoAttacco = Time.time + IntervalloAttacchi;
                    EseguiAttacco();
                    Debug.Log("Setting Attack.");
                }

            if(distanza > 4)
                {
                    statoAttuale = statoNemico.inseguimento;
                    Debug.Log("Current Enemy State: Following.");
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

}
