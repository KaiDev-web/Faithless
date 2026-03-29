using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public float maxHealth;
    public float actualHealth;

    void Start()
    {
        actualHealth = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AttackHitBox")) 
        {
            actualHealth = maxHealth - 3; 
            Debug.Log("Damage Inflicted.");
        }

        if (actualHealth -= 0) 
        {
            Debug.Log("Enemy killed.");
        }
        else
        {
            Debug.Log("Everything works fine.");
        }
    }
}
