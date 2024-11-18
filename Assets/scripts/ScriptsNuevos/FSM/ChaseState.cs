using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IState
{
    private IAEnemiga ia;

    public ChaseState(IAEnemiga ia)
    {
        this.ia = ia;
    }

    public void Enter(){}

    public void Execute()
    {
        Transform target = GetClosestPlayer();

        ia.agent.SetDestination(target.position);
        ia.transform.LookAt(target.position);   

        if (Vector3.Distance(target.position, ia.agent.transform.position) <= ia.attackrange)// revisa si el jugador esta en rango de ataque
        {
            ia.ChangeState(ia.attackState);
        }
        
        float distanceToPlayer1 = Vector3.Distance(ia.player1.position, ia.agent.transform.position);
        float distanceToPlayer2 = Vector3.Distance(ia.player2.position, ia.agent.transform.position);

        if (distanceToPlayer1 >= ia.sightrange || distanceToPlayer2 >= ia.sightrange)// revisa si el jugador esta en el rango de vision
        {
            ia.ChangeState(ia.patrolState);
        }
    }

    private Transform GetClosestPlayer()// busca coordenadas a donde dirijirse
    {
        float distanceToPlayer1 = Vector3.Distance(ia.player1.position, ia.agent.transform.position);
        float distanceToPlayer2 = Vector3.Distance(ia.player2.position, ia.agent.transform.position);

        return distanceToPlayer1 < distanceToPlayer2 ? ia.player1 : ia.player2;
    }

    public void Exit(){}
}
