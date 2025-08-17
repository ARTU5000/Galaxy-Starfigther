using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fragmentmove : MonoBehaviour
{
    public float move1;
    public float move2;
    private float movetotal1;
    private float movetotal2;
    Rigidbody rb;

    public float lifetime;
    private float timer;
    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        lifetime = 3f;
        timer = 0f;
        movetotal1 = Random.Range(move1, move2);
        movetotal2 = Random.Range(move2, move1);
        rb = GetComponent<Rigidbody>();

        initialScale = transform.localScale; 
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(new Vector3(movetotal2,0, movetotal1));

        timer += Time.deltaTime;

        float scaleFactor = Mathf.Lerp(1f, 0f, timer / 1);
        transform.localScale = initialScale * scaleFactor;

        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}