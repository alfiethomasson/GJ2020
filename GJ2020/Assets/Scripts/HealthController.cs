using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthController : MonoBehaviour
{
    public PlayerController player;
    public TextMeshProUGUI text;
    private static int health = 100;
    private static int maxHealth = 100;

    public void OnDamage(int damage) {

        health = health - damage;

        text.text = health + "/" + maxHealth;
        player.UpdateHealth(health);
    }

    public void OnHeal(int heal)
    {

        health = health + heal;
        if (health > maxHealth) {

            health = maxHealth;
        }

        text.text = health + "/" + maxHealth;
        player.UpdateHealth(health);
    }

    
}
