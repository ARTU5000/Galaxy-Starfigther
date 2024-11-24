using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float timr = 0;
    public Text textotimer;

    void Update()
    {
        timr += Time.deltaTime;

        int minutos = Mathf.FloorToInt(timr / 60);
        int segundos = Mathf.FloorToInt(timr % 60);

        // Formatea el texto para mostrar siempre dos dígitos
        textotimer.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
