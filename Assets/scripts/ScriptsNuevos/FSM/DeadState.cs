using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    private IAEnemiga ia;

    public DeadState(IAEnemiga ia)
    {
        this.ia = ia;
    }

    public void Enter()//cantidad de fragmentos creados
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject.Instantiate(ia.fragment, ia.transform.position, Quaternion.identity);
        }

        GameObject.Destroy(ia.gameObject);
    }

    public void Execute(){}
    public void Exit(){}
}
