using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCheck : MonoBehaviour
{

    public bool onceiling;

    //private IEnumerator Waittwo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Environment")
        {
            onceiling = true;
            StartCoroutine(Waittwo());
        }
    }
    IEnumerator Waittwo()
    {
        yield return new WaitForSeconds(2);
        onceiling = false;
    }
}
