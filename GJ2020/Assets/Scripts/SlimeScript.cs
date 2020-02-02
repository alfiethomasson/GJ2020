using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject player;
    public GameObject bullet;

        RaycastHit hit;
    int layermask = 1 << 13;
   

    void Start()
    {
        //Vector3 bulletpos = new Vector3(transform.position.x + 5, transform.position.y, 0.0f);
        StartCoroutine(AI());
    }

    // Update is called once per frame
    void Update()
    {       
        //Vector3 playerDir = player.transform.position - transform.position;
        ////playerDir.Normalize();

        //if(Physics.Raycast(transform.position, playerDir, out hit, 20, layermask));
        //{
        //    Debug.DrawRay(transform.position, playerDir, Color.green);
        //  //  if(hit.collider != null)
        //   // {
        //    //if(hit.gameObject.tag == "Player")
        //    //{
        //     //   Debug.Log("working");
        //   // }
        //   // }
        //}
    }

    IEnumerator AI()
    {
        Vector3 bulletpos = new Vector3(transform.position.x - 5, transform.position.y, 0.0f);
        while (true)
        {
            yield return new WaitForSeconds(2);
            Vector3 playerDir = player.transform.position - transform.position;
            //playerDir.Normalize();

            if (Physics.Raycast(transform.position, playerDir, out hit, 20, layermask)) ;
            {

                Debug.DrawRay(transform.position, playerDir, Color.green);
                GameObject b = Instantiate(bullet, bulletpos, transform.rotation);
                playerDir.Normalize();
                b.GetComponent<Rigidbody2D>().velocity = playerDir*6.0f;
            }
        }
    }

}
