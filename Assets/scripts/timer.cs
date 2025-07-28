using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float timr;
    public Text textotimer;

    public DataManager dataManager;

    void Start()
    {
        dataManager = GameObject.FindObjectOfType<DataManager>();

        timr = dataManager.maxPlayTime;  // Inicializa el timer con el valor máximo
    }

    void Update()
    {
        timr -= Time.deltaTime;

        if (timr < 0)
        {
            timr = 0;
        }

        int minutos = Mathf.FloorToInt(timr / 60);
        int segundos = Mathf.FloorToInt(timr % 60);

        // Formatea el texto para mostrar siempre dos dígitos
        textotimer.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
