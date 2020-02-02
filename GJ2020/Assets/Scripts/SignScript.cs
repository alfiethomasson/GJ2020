using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignScript : MonoBehaviour
{



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 13)
        {
            SceneManager.LoadScene("GameScene");
        }


    }

   
}
