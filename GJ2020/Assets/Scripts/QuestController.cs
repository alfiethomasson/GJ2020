using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class QuestController : MonoBehaviour
{
    
    public static int QuestCounter = 0;
    public TextMeshProUGUI text;


    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == 11)
        {
            if (QuestCounter < 8)
            {
                QuestCounter++;
            }
            else
            {
                QuestCounter = 0;
            }

            text.text = "Quest progress updated to: " + QuestCounter;
        }
    }
        
}
