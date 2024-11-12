using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACreated : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        float pos = Random.Range(1, 5);
        float posx, posz;

        if (pos == 1)
        {
            posx = Random.Range(-140, 141);
            transform.position = new Vector3(posx, 1.6f, -105);
        }
        else if (pos == 2)
        {
            posx = Random.Range(-140, 141);
            transform.position = new Vector3(posx, 1.6f, 70);
        }
        else if (pos == 3)
        {
            posz = Random.Range(-95, 61);
            transform.position = new Vector3(-150, 1.6f, posz);
        }
        else
        {
            posz = Random.Range(-95, 61);
            transform.position = new Vector3(150, 1.6f, posz);
        }
    }
}
