using BaseGameLogic.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HideState : IState, IOnUpdate
{
    [RequiredReference] private Transform transform = null;
    [RequiredReference] private NavMeshAgent navMeshAgent = null;

    private Transform _hideoutTransform = null;

    public HideState(Transform hideoutTransform)
    {
        _hideoutTransform = hideoutTransform;
    }

    public void OnEnter()
    {
        navMeshAgent.enabled = false;
        transform.position = _hideoutTransform.position;
    }

    public void OnExit()
    {
        navMeshAgent.enabled = true;
    }

    public void OnUpdate()
    {
    }
}
