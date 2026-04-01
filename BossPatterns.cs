using UnityEngine;
using System.Collections; 

public class BossPatterns : MonoBehaviour
{
    public enum BossState { Idle, Choose, Attack };
    public BossState currentState = BossState.Idle;

    [Header("Settings")]
    public Transform player;
    public float attackTimer = 2f;
    public float movementSpeed = 5f;

    public float distance = 6;
    
    private float currentTimer;
    private int lastAttack = -1;
    private int activeAttackID = -1;

    void Start()
    {
        currentTimer = attackTimer;
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        
        if (currentState == BossState.Idle)
        {
            currentTimer -= Time.deltaTime;
            if (currentTimer <= 0)
            {
                currentState = BossState.Choose;
            }

            if (distance < 6)
            {
                currentState = BossState.Choose;
            }
        }

        if (currentState == BossState.Choose)
        {
            ChooseAttack();
        }

        if (currentState == BossState.Attack)
        {
            ApplyAttackMovement(activeAttackID);
        }
    }

    void ChooseAttack()
    {
        int newAttack;
        do
        {
            newAttack = Random.Range(1, 4); 
        } while (newAttack == lastAttack);

        lastAttack = newAttack;
        activeAttackID = newAttack;
        

        if (activeAttackID == 2) 
        {
            StartCoroutine(LeapAttack()); 
        }
        else 
        {
            currentState = BossState.Attack;
        }
    }

    void ApplyAttackMovement(int id)
    {
        switch (id)
        {
            case 1: 
                transform.position = Vector2.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
                
                
                if (Vector2.Distance(transform.position, player.position) < 0.1f) 
                    ResetToIdle();
                break;

            case 3: 
              
                Invoke("ResetToIdle", 1f); 
                break;
        }
    }


    IEnumerator LeapAttack()
    {
        currentState = BossState.Attack;
        

        Vector2 upPos = (Vector2)transform.position + Vector2.up * 3f;
        while(Vector2.Distance(transform.position, upPos) > 0.1f) {
            transform.position = Vector2.MoveTowards(transform.position, upPos, movementSpeed * Time.deltaTime);
            yield return null;
        }


        yield return new WaitForSeconds(0.5f);


        Vector2 targetPos = player.position;
        while(Vector2.Distance(transform.position, targetPos) > 0.1f) {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, (movementSpeed * 2) * Time.deltaTime);
            yield return null;
        }

        ResetToIdle();
    }

    void ResetToIdle()
    {
        activeAttackID = -1;
        currentTimer = attackTimer;
        currentState = BossState.Idle;
    }
}
