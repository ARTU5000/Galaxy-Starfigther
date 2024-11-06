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
    // Start is called before the first frame update
    void Start()
    {
        movetotal1 = Random.Range(move1, move2);
        movetotal2 = Random.Range(move2, move1);
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject,3);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(new Vector3(movetotal2,0, movetotal1));
    }
}
