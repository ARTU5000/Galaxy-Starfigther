using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAspawn : MonoBehaviour
{
    public enum STATE { RELEASE, STAY }
    public STATE state;

    public GameObject IAship;
    private float posx;
    private float posz;
    private float next;
    public float spawn;
    private bool spawner;

    // Update is called once per frame
    void SetClone()
    {
        GameObject clone = Instantiate(IAship);

        float pos = Random.Range(1,5);

        if (pos == 1)
        {
            posx = Random.Range(-140, 141);
            clone.transform.position = new Vector3(posx, 1.6f, -105);
        }
        else if(pos == 2)
        {
            posx = Random.Range(-140, 141);
            clone.transform.position = new Vector3(posx, 1.6f, 70);
        }
        else if (pos == 3)
        {
            posz = Random.Range(-95, 61);
            clone.transform.position = new Vector3(-150, 1.6f, posz);
        }
        else
        {
            {
                posz = Random.Range(-95, 61);
                clone.transform.position = new Vector3(150, 1.6f, posz);
            }
        }
    }
    void Update()
    {
        if (spawner == true && Time.time >= next)
        {
            SetClone();
            SetClone();
            SetClone();
            SetClone();
            spawner = false;
        }
        else if (spawner == false)
        {
            next = Time.time + spawn;
            spawner = true;
        }
    }
}
