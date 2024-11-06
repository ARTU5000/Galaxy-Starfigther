using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_shoot : MonoBehaviour
{
    public GameObject plasma;
    private float next;
    private int total = 24;
    private int recharge = 1;
    private int Heat;
    private bool fire = true;


    void Update()
    {
        if(fire == true && Input.GetButtonDown("Fire3P1"))
        {
            Instantiate(plasma, transform.position,transform.rotation);
            Heat += 1;
            if (Heat < total)
            {
                fire = false;
            }       
        }
        else if(fire == false)
        {
            next = Time.time + recharge;
            Heat = 0;
            fire = true;
        }

    }
}
