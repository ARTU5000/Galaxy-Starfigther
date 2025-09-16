using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public float timer;
    private float start;
    public float end;
    private Vector3 initialScale;
    // Start is called before the first frame update

    private void OnEnable()
    {
        start = Time.time;
        end = Time.time + timer;
        initialScale = transform.localScale; 
    }

    // Update is called once per frame
    void Update()
    {
        float scaleFactor = Mathf.Lerp(1f, 0f, (Time.time - start) / (end - start));
        transform.localScale = initialScale * scaleFactor;
        if (Time.time >= end)
        {
            Destroy(gameObject);
        }
    }
}
