using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hsP2 : MonoBehaviour
{
    public GameObject plasma;
    private float next;
    public float shootvel;
    private int total = 6;
    private int recharge = 2;
    private int Heat;
    private bool fire = true;


    void Update()
    {
        if (fire == true && Input.GetButtonDown("Fire2P2") && Time.time >= next)
        {
            Instantiate(plasma, transform.position, transform.rotation);
            next = Time.time + shootvel;
            Heat += 1;
            if (Heat < total)
            {
                fire = false;
            }
        }
        else if (fire == false)
        {
            next = Time.time + recharge;
            Heat = 0;
            fire = true;
        }

    }
}
