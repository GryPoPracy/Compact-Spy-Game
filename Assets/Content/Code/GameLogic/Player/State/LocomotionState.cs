using System.Collections;
using System.Collections.Generic;

using BaseGameLogic.States;
using Interactions;
using UnityEngine;
using UnityEngine.AI;

namespace Player.States
{
    public class LocomotionState : IState, IOnUpdate
    {
        [RequiredReference] private NavMeshAgent _agent = null;
        [RequiredReference] private CommandProcesor procesor = null;
        [RequiredReference] private StateHandler _stateHandler = null;

        private IInteraction objectToUse = null;

        public LocomotionState() {}

        public void OnEnter() {}

        public void OnExit() {}

        public void OnUpdate()
        {
            if (procesor.CommandQueue.Count > 0)
            {
                var commadn = procesor.CommandQueue.Dequeue();
                _agent.SetDestination(commadn.Destination);
                objectToUse = commadn.GameObject.GetComponent<IInteraction>();
            }
            else if(_agent.remainingDistance < 0.5f && objectToUse != null) 
            {
                objectToUse.Interact(_stateHandler);
                objectToUse = null;
            }
        }
    }
}