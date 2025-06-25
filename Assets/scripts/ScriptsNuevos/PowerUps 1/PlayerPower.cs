using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{
    public hp1 hpScript;
    int powerNum;

    // Start is called before the first frame update
    void Start()
    {
        hpScript = this.GetComponent<hp1>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 16)
        {
            powerNum = Random.Range(0, 10);
            getPower();
        }
    }

    public void getPower()
    {
        switch (powerNum)
        {
            case 0:
            case 1:
            case 2:
                if (hpScript.actual_life <= 15)
                    hpScript.actual_life += 5;
                else
                    hpScript.actual_life = 20;
                break;
            case 3:
            case 4:
            case 5:
                hpScript.actual_life = 20;
                break;
            case 6:
            case 7:
            case 8:
                hpScript.actual_shield = 20;
                break;
            case 9:
                if (hpScript.total_ships > hpScript.total_ships)
                    hpScript.ships++;
                break;
            default:
                if (hpScript.actual_life <= 15)
                    hpScript.actual_life += 5;
                else
                    hpScript.actual_life = 20;
                break;
        }
    }
}
