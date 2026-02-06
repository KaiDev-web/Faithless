using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class PlayerHealt : MonoBehaviour
{
    public Image Bar;
    public TextMeshProUGUI healthText;
    public float maxHealth = 100;
    public float health;

    private void Start()
    {
        health = maxHealth;
    }


    void Update()
    {
        float fillValue = Mathf.Clamp01(health / maxHealth);
        Bar.fillAmount = fillValue;

       
        if (healthText != null)
        {
            healthText.text = (fillValue * 100).ToString("F0") + "%";
        }
    }

}
