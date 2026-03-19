using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackSystem : MonoBehaviour
{
    public GameObject attackHitBox;
    public GameObject attackHitBoxDown;
    public GameObject attackHitBoxUp;
    public float hitboxWaitTime = 1;

    public void Start()
    {
        attackHitBox.gameObject.SetActive(false);
        attackHitBoxDown.gameObject.SetActive(false);
        attackHitBoxUp.gameObject.SetActive(false);
    }
    
    private void Update()
    {
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            Debug.Log("Right/Left.");

            StartCoroutine(AttackExecuteLeft());
        }

        if (Keyboard.current.xKey.wasPressedThisFrame && Keyboard.current.downArrowKey.isPressed)
        {
            Debug.Log("Down.");

            StartCoroutine(AttackExecuteDown());
        }

        if (Keyboard.current.xKey.wasPressedThisFrame && Keyboard.current.upArrowKey.isPressed)
        {
            Debug.Log("Up.");

            StartCoroutine(AttackExecuteUp());
        }
    }

    IEnumerator AttackExecuteLeft()
    {
        attackHitBox.gameObject.SetActive(true);
        yield return new WaitForSeconds(hitboxWaitTime);
        attackHitBox.gameObject.SetActive(false);
    }

    IEnumerator AttackExecuteDown()
    {
        attackHitBoxDown.gameObject.SetActive(true);
        yield return new WaitForSeconds(hitboxWaitTime);
        attackHitBoxDown.gameObject.SetActive(false);
    }

    IEnumerator AttackExecuteUp()
    {
        attackHitBoxUp.gameObject.SetActive(true);
        yield return new WaitForSeconds(hitboxWaitTime);
        attackHitBoxUp.gameObject.SetActive(false);
    }
}
