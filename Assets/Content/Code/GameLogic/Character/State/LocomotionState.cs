using System.Collections;
using System.Collections.Generic;

using BaseGameLogic.States;
using Interactions;
using UnityEngine;
using UnityEngine.AI;

namespace Character.States
{
    public class LocomotionState : IState, IOnUpdate, IOnAwake
    {
        [RequiredReference] private NavMeshAgent _agent = null;
        [RequiredReference] private CommandProcesor _procesor = null;
        [RequiredReference] private StateHandler _stateHandler = null;

        private IInteraction _objectToUse = null;

        public LocomotionState() {}

        public void OnAwake()
        {
            if (_procesor.CurrenntCommand != null)
            {
                ExecuteCommand();
            }
        }

        public void OnEnter() {}

        public void OnExit() {}

        public void OnUpdate()
        {
            if(_procesor.CurrenntCommand != null)
            {
                ExecuteCommand();
            }
            else if(_agent.remainingDistance < 0.5f && _objectToUse != null) 
            {
                _objectToUse.Interact(_stateHandler);
                _objectToUse = null;
            }
        }

        public void ExecuteCommand()
        {
            _agent.SetDestination(_procesor.CurrenntCommand.HitPosition);
            _objectToUse = _procesor.CurrenntCommand.GameObject.GetComponent<IInteraction>();
            _procesor.Consume();
        }
    }
}