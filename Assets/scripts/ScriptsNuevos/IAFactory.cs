using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAFactory
{
    public GameObject CreateIA(GameObject iaPrefab)
    {
        GameObject clone = GameObject.Instantiate(iaPrefab);
        PositionIA(clone);
        return clone;
    }

    private void PositionIA(GameObject iaInstance)
    {
        float pos = Random.Range(1, 5);
        float posx, posz;

        if (pos == 1)
        {
            posx = Random.Range(-140, 141);
            iaInstance.transform.position = new Vector3(posx, 1.6f, -105);
        }
        else if (pos == 2)
        {
            posx = Random.Range(-140, 141);
            iaInstance.transform.position = new Vector3(posx, 1.6f, 70);
        }
        else if (pos == 3)
        {
            posz = Random.Range(-95, 61);
            iaInstance.transform.position = new Vector3(-150, 1.6f, posz);
        }
        else
        {
            posz = Random.Range(-95, 61);
            iaInstance.transform.position = new Vector3(150, 1.6f, posz);
        }
    }
}