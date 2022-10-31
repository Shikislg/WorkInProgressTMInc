using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int maxHealth;
    public static int health;

    public void Damage(int amount)
    {
        if (health < amount)
        {
            Debug.Log("Dead");
        }
        else
        {
            health -= amount;
        }
    }
    public void Heal(int amount)
    {
        if (health + amount > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += amount;
        }
    }
    public void Heal(float percentAmount)
    {
        if(health + (health * percentAmount) > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += (int)(health * percentAmount);
        }
    }
}
