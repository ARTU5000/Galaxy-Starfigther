using UnityEngine;

public class RotateY : MonoBehaviour
{
    public float rotationSpeed = 30f; // Grados por segundo

    void Update()
    {
        // Rotar continuamente sobre el eje Y
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}