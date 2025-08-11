using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PowerUpObject : MonoBehaviour
{
    public NavMeshAgent agent;

    private Vector3 walkpoint;

    public bool used;

    
    public DataManager dataManager;
    public int multiplier;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        used = false;
        dataManager = GameObject.FindObjectOfType<DataManager>();
        multiplier = dataManager.powerUpSpawnMultiplier;
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }
    }
}
