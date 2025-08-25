using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStartAnim : MonoBehaviour
{
    void OnEnable() 
    {
        GetComponent<Animation>().Play("SAnimMenu"); 
    }
}