using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAFactory : IProduct
{
    public GameObject CreateIA(GameObject iaPrefab)
    {
        return GameObject.Instantiate(iaPrefab);
    }
}