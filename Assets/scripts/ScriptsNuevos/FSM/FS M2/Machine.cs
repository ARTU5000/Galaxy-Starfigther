using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public EStates currentState;
    private Enemy ia;
    
    public Machine(Enemy ia)
    {
        this.ia = ia;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(EStates.Patrol);//patrulla
    }

    // Update is called once per frame
    void Update()
    {
        // Lógica de transición entre estados
        switch (currentState)
        {
            case EStates.Patrol:
                float distanceToPlayer1 = Vector3.Distance(ia.player1.position, ia.agent.transform.position);
                float distanceToPlayer2 = Vector3.Distance(ia.player2.position, ia.agent.transform.position);

                if ((distanceToPlayer1 <= ia.sightrange && ia.player1.gameObject.activeSelf) || (distanceToPlayer2 <= ia.sightrange && ia.player2.gameObject.activeSelf))// revisa si el jugador esta en el rango de vision
                {
                    if (distanceToPlayer1 <= ia.attackrange || distanceToPlayer2 <= ia.attackrange)// revisa si el jugador esta en rango de ataque
                        ChangeState(EStates.Attack);//ataca
                    else
                        ChangeState(EStates.Follow);//persigue
                }
                break;

            case EStates.Follow:
                if (Vector3.Distance(ia.target.position, ia.agent.transform.position) <= ia.attackrange)// revisa si el jugador esta en rango de ataque
                    ChangeState(EStates.Attack);//ataca

                if (Vector3.Distance(ia.target.position, ia.agent.transform.position) >= ia.sightrange || !ia.target.gameObject.activeSelf)// revisa si el jugador esta en el rango de vision
                    ChangeState(EStates.Patrol);//patrulla
                break;

            case EStates.Attack:
                
                if (Vector3.Distance(ia.target.position, ia.agent.transform.position) > ia.attackrange)// revisa si el jugador esta en rango de ataque
                {
                    if (Vector3.Distance(ia.target.position, ia.agent.transform.position) >= ia.sightrange || !ia.target.gameObject.activeSelf)// revisa si el jugador esta en el rango de vision
                        ChangeState(EStates.Patrol);//patrulla
                    else
                        ChangeState(EStates.Follow);//persigue
                }
                break;

            case EStates.Die:
                break;
            default:
                ChangeState(EStates.Patrol);//patrulla
                break;
        }
    }
    
    public void ChangeState(EStates newState)
    {
        // Cambia al nuevo estado
        currentState = newState;
    }
}
