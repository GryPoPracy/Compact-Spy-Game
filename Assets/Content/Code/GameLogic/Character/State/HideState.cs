using UnityEngine;
using UnityEngine.AI;

using System.Collections;
using System.Collections.Generic;

using BaseGameLogic.States;
using Interactions;

namespace Character.States
{
    public class HideState : IState, IOnUpdate
    {
        [RequiredReference] private Transform _transform = null;
        [RequiredReference] private Collider _collider = null;
        [RequiredReference] private StateHandler _stateHandler = null;
        [RequiredReference] private InputHandlingModule _innputHandler = null;

        private Transform _hideoutTransform = null;
        private Vector3 _oldPosition = Vector3.zero;

        public HideState(Transform hideoutTransform)
        {
            _hideoutTransform = hideoutTransform;
        }

        public void OnEnter()
        {
            _collider.enabled = false;
            _oldPosition = _transform.position;
            _transform.position = _hideoutTransform.position;
        }

        public void OnExit()
        {
            _transform.position = _oldPosition;
            _collider.enabled = true;
        }

        public void OnUpdate()
        {
            if (_innputHandler.CurrentInputSource.MovementVector.x != 0)
                _stateHandler.ExitState();
        }
    }
}