using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        Vector3 playerDir = player.transform.position - transform.position;

        if(Physics.Raycast(transform.position, playerDir, out hit, 50.0f));
        {
            Debug.DrawRay(transform.position, playerDir, Color.green);
            if(hit.collider.name == "Player")
            {
                Debug.Log("working");
            }
        }
    }
}
