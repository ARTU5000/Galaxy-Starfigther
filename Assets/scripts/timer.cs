using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float timr = 0;
    public Text textotimer;

    private int seg;
    private int min;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timr += Time.deltaTime;

        if(timr >= 1)
        {
            seg++;
            timr = 0;
        }

        if (seg >= 60)
        {
            min++;
            seg = 0;
        }

        textotimer.text = min.ToString() + ":" + seg.ToString();
    }
}
