using BaseGameLogic.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LocomotionState : IState, IOnUpdate
{
    [RequiredReference] private NavMeshAgent _agent = null;
    [RequiredReference] private CommandProcesor procesor = null;

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
        if(procesor.CommandQueue.Count > 0)
        {
            var commadn = procesor.CommandQueue.Dequeue();
            _agent.destination = commadn.Destination;
        }
    }
}
