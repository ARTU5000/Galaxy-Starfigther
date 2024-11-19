using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private IAEnemiga ia;
    private bool attacked;

    public AttackState(IAEnemiga ia)
    {
        this.ia = ia;
    }

    public void Enter()
    {
        attacked = false;
    }

    public void Execute()
    {
        if (!attacked)
        {
            GameObject.Instantiate(ia.plasma, ia.shoot.transform.position, ia.shoot.transform.rotation);
            attacked = true;
            ia.Invoke(nameof(ia.ResetAttack), ia.timebetweenattacks);
        }

        Transform target = GetClosestPlayer();
        ia.agent.SetDestination(target.position);
        ia.transform.LookAt(target.position);   

        if (Vector3.Distance(target.position, ia.agent.transform.position) > ia.attackrange)// revisa si el jugador esta en rango de ataque
        {
            if (Vector3.Distance(target.position, ia.agent.transform.position) >= ia.sightrange)// revisa si el jugador esta en el rango de vision
                ia.ChangeState(ia.patrolState);//patrulla
            else
                ia.ChangeState(ia.chaseState);//persigue
        }
    }

    private Transform GetClosestPlayer()// busca coordenadas a donde dirijirse
    {
        float distanceToPlayer1 = Vector3.Distance(ia.player1.position, ia.agent.transform.position);
        float distanceToPlayer2 = Vector3.Distance(ia.player2.position, ia.agent.transform.position);

        return distanceToPlayer1 < distanceToPlayer2 ? ia.player1 : ia.player2;
    }
    public void ResetAttack()
    {
        attacked = false;
    }

    public void Exit(){}
}
