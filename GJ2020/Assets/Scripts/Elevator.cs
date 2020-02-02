using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
   
    public float elevatorTime;

    public float elevatorSpeed;

    private bool goingUp = true;

    private Vector2 velocity;

    private bool inWait = false;

    void Start()
    {
        velocity = new Vector2(0.0f, 0.0f);
    }

    void FixedUpdate()
    {
        if(goingUp && inWait == false)
        {
        velocity.y = elevatorSpeed;
        StartCoroutine(ElevateTime());
        }
        else if (!goingUp && inWait == false)
        {
            velocity.y = -elevatorSpeed;
            StartCoroutine(ElevateTime());
        }

           transform.Translate(velocity * Time.deltaTime);

    }

    IEnumerator ElevateTime()
    {
        inWait = true;
        yield return new WaitForSeconds(3);
        goingUp = !goingUp;
        inWait = false;
    }

}
