using BaseGameLogic.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HideState : IState, IOnUpdate
{
    [RequiredReference] private Transform transform = null;
    [RequiredReference] private NavMeshAgent navMeshAgent = null;
    [RequiredReference] private Collider collider = null;

    private Transform _hideoutTransform = null;

    public HideState(Transform hideoutTransform)
    {
        _hideoutTransform = hideoutTransform;
    }

    public void OnEnter()
    {
        navMeshAgent.enabled = false;
        collider.enabled = false;
        transform.position = _hideoutTransform.position;
    }

    public void OnExit()
    {
        collider.enabled = true;
        navMeshAgent.enabled = true;
    }

    public void OnUpdate()
    {
    }
}
