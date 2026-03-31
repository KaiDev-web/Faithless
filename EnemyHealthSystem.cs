using System;
using UnityEngine;

public class UniversalEnemyHealth : MonoBehaviour
{
    public GameObject attackHitboxLeft;
    public GameObject attackHitBoxUp;
    public GameObject attackHitBoxDown;
    public float health;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AttackHitbox"))
        {
            health -= 3;
            
            Debug.Log("Enemy attacked.");
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            
            Debug.Log("Let's go! The enemy died.");
        }
    }
}

