using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAFactory
{
    public GameObject CreateIA(GameObject iaPrefab)
    {
        GameObject clone = GameObject.Instantiate(iaPrefab);
        return clone;
    }
}