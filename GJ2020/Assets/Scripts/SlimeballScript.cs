using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeballScript : MonoBehaviour
{

    public HealthController health;
    // Start is called before the first frame update
    void Start()
    {
    health = GameObject.Find("health ui").GetComponent<HealthController>();
    StartCoroutine(Timeout());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 13)
        {

            health.OnDamage(10);
            Destroy(gameObject);
        }


    }

    IEnumerator Timeout() {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
