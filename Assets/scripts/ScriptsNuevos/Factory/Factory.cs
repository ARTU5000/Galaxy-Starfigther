using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : IProduct
{
    public GameObject CreateIA(GameObject iaPrefab)
    {
        return GameObject.Instantiate(iaPrefab);
    }
}
