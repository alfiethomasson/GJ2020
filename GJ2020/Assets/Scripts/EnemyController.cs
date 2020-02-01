using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 5.0f;
    public bool alive = true;
    public float angrySpeed = 15.0f;
    public bool isAngry = false;
    public float direction = 1.0f;
    private GameObject player;
    
    Vector2 velocity;

    Rigidbody2D rb;

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(0.0f, 0.0f);
        StartCoroutine(AI());
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (isAngry) {
            velocity.x = (angrySpeed*direction);
        }
        else
        {
            velocity.x = (speed*direction);
        }

       
        transform.Translate(velocity * Time.deltaTime);


    }


    // Update is called once per frame


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isAngry) {
            if (collision.gameObject.layer == 13)
            {
                isAngry = true;
            }
        }
        
    }

    IEnumerator AI()
    {
        while (alive) {
            while (!isAngry)
            {

                yield return new WaitForSeconds(1);
                yield return null;
                direction = -direction;
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;

            }

            while (isAngry) {
                Vector2 result = player.transform.position - transform.position ;
                result.Normalize();
                direction = result.x;
                yield return null;
            }
        }  
    }
}
