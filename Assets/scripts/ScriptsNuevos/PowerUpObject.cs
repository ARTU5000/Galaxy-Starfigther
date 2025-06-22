using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PowerUpObject : MonoBehaviour
{
    public NavMeshAgent agent;

    private Vector3 walkpoint;
    
    private Transform ObjT;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(walkpoint, agent.transform.position) <= 20f)
        {
            SetWalkPoint();
        }

        agent.SetDestination(walkpoint);
    }

    private void SetWalkPoint()// busca coordenadas a donde dirijirse
    {
        float randomX = Random.Range(-140, 140);
        float randomZ = Random.Range(-95, 60);
        walkpoint = new Vector3(randomX, transform.position.y, randomZ);
    }

    private void MoveLimits()
    {
        Vector3 ObjPosition = ObjT.position;

        // Obtener los bordes de la cámara en espacio mundial
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.y));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.transform.position.y));

        // Limitar la posición del jugador
        ObjPosition.x = Mathf.Clamp(ObjPosition.x, bottomLeft.x, topRight.x);
        ObjPosition.z = Mathf.Clamp(ObjPosition.z, bottomLeft.z, topRight.z);

        // Asignar la posición limitada
        ObjT.position = ObjPosition;
    }
}
