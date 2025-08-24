using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject fragment;
    public int number;

    private float radius = 1f; 
    private float initialRotation = 0f; 
    private float rotationIncrement;
    
    void Start()
    {
        if (number < 1)
            number = 1;

        rotationIncrement = 360 / number;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        OnDisable();
    }
    
    private void OnDisable()
    {
        for (int i = 0; i < number; i++)
        {
            // Calcular ángulo en radianes
            float angle = i * Mathf.PI * 2 / number;
            
            // Calcular posición en círculo
            Vector3 spawnPos = transform.position + new Vector3(
                Mathf.Cos(angle) * radius,
                0,
                Mathf.Sin(angle) * radius
            );

            // Calcular rotación progresiva
            float currentRotation = initialRotation + (i * rotationIncrement);
            Quaternion spawnRot = Quaternion.Euler(0, currentRotation, 0);

            // Instanciar fragmento
            Instantiate(fragment, spawnPos, spawnRot);
        }
    }
}
