using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    private IAEnemiga ia;
    private Vector3 walkpoint;

    public PatrolState(IAEnemiga ia)
    {
        this.ia = ia;
    }

    public void Enter()
    {
        SetWalkPoint();
    }

    public void Execute()
    {
        float distanceToPlayer1 = Vector3.Distance(ia.player1.position, ia.agent.transform.position);
        float distanceToPlayer2 = Vector3.Distance(ia.player2.position, ia.agent.transform.position);

        if (distanceToPlayer1 <= ia.sightrange || distanceToPlayer2 <= ia.sightrange)// revisa si el jugador esta en el rango de vision
        {
            ia.ChangeState(ia.chaseState);
        }

        if (Vector3.Distance(walkpoint, ia.agent.transform.position) <= 10f)
        {
            SetWalkPoint();
        }

        ia.agent.SetDestination(walkpoint);
    }

    private void SetWalkPoint()// busca coordenadas a donde dirijirse
    {
        float randomX = Random.Range(-140, 140);
        float randomZ = Random.Range(-95, 60);
        walkpoint = new Vector3(randomX, ia.transform.position.y, randomZ);
    }

    public void Exit(){}
}
