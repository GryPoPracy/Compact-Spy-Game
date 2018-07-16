using UnityEngine;
using UnityEngine.AI;

using System.Collections;
using System.Collections.Generic;

using BaseGameLogic.States;
using Interactions;

namespace Player.States
{
    public class HideState : IState, IOnUpdate
    {
        [RequiredReference] private Transform _transform = null;
        [RequiredReference] private NavMeshAgent _navMeshAgent = null;
        [RequiredReference] private Collider _collider = null;
        [RequiredReference] private CommandProcesor _procesor = null;
        [RequiredReference] private StateHandler _stateHandler = null;

        private Transform _hideoutTransform = null;

        public HideState(Transform hideoutTransform)
        {
            _hideoutTransform = hideoutTransform;
        }

        public void OnEnter()
        {
            _navMeshAgent.enabled = false;
            _collider.enabled = false;
            _transform.position = _hideoutTransform.position;
        }

        public void OnExit()
        {
            _collider.enabled = true;
            _navMeshAgent.enabled = true;
        }

        public void OnUpdate()
        {
            if (_procesor.CurrenntCommand != null)
            {
                _stateHandler.ExitState();
            }
        }
    }
}