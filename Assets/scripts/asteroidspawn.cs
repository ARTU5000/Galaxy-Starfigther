using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidspawn : MonoBehaviour
{
    public enum STATE { RELEASE, STAY }
    public STATE state;

    public GameObject asteroid;
    public float x1;
    public float x2;
    private float next;
    public float spawn;
    private float ready;
    private bool spawner;

    // Start is called before the first frame update
    void Start()
    {//<>


    }//</>

    // Update is called once per frame
    void SetClone()
    {
        GameObject clone = Instantiate(asteroid);

        float posX = Random.Range(x1, x2);
        clone.transform.position = new Vector3(posX, 3.6f, 70);
    }
    void Update()
    {
        if(spawner == true && Time.time>=next )
        {
            SetClone();
            SetClone();
            SetClone();
            SetClone();
            ready += 1;
            spawner = false;
        }
        else if (spawner == false)
        {
            next = Time.time + spawn;
            spawner = true;
        }
    }
}
