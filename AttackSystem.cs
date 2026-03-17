using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackSystem : MonoBehaviour
{
    public GameObject attackHitBox;
    public float hitboxWaitTime = 1;

    public void Start()
    {
        attackHitBox.gameObject.SetActive(false);
    }
    
    private void Update()
    {
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            Debug.Log("Dude this attack is fire.");

            StartCoroutine(AttackExecute());
        }
    }

    IEnumerator AttackExecute()
    {
        attackHitBox.gameObject.SetActive(true);
        yield return new WaitForSeconds(hitboxWaitTime);
        attackHitBox.gameObject.SetActive(false);
        
    }
}
