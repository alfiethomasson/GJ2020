using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthController : MonoBehaviour
{
    public PlayerController player;
    public TextMeshProUGUI text;
    public GameObject hundred;
    public GameObject seventyfive;
    public GameObject fifty;
    public GameObject twentyfive;
    private static int health = 100;
    private static int maxHealth = 100;

    public void OnDamage(int damage) {

        health = health - damage;

        text.text = health + "/" + maxHealth;
        player.UpdateHealth(health);
        GUIUpdate();
    }

    public void OnHeal(int heal)
    {

        health = health + heal;
        if (health > maxHealth) {

            health = maxHealth;
        }

        text.text = health + "/" + maxHealth;
        player.UpdateHealth(health);
        GUIUpdate();
    }


    void GUIUpdate() {
        if (health >= 76)
        {
            hundred.SetActive(true);
            seventyfive.SetActive(true);
            fifty.SetActive(true);
            twentyfive.SetActive(true);

        }
        else if (health >= 51)
        {

            hundred.SetActive(false);
            seventyfive.SetActive(true);
            fifty.SetActive(true);
            twentyfive.SetActive(true);
        }
        else if (health >= 26)
        {

            hundred.SetActive(false);
            seventyfive.SetActive(false);
            fifty.SetActive(true);
            twentyfive.SetActive(true);
        }
        else if (health > 1)
        {
            hundred.SetActive(false);
            seventyfive.SetActive(false);
            fifty.SetActive(false);
            twentyfive.SetActive(true);
        }
        else {
            hundred.SetActive(false);
            seventyfive.SetActive(false);
            fifty.SetActive(false);
            twentyfive.SetActive(false);
        }
    }
    
}
