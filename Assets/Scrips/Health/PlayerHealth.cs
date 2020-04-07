using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Setting limit of health
    public int maxHealth = 100;
    public int currentHealth;

    //Reference to the healthbar
    public HealthBar healthBar;
   
    void Start()
    {
        //Player starts with max amount of health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        //Placeholder condition
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Deplete health by specified amount
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        //Update healthbar when taking damage
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
