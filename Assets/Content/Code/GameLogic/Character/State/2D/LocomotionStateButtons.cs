using BaseGameLogic.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionStateButtons : IState, IOnUpdate
{
    [RequiredReference] private Transform _transform = null;
    [RequiredReference] private StateHandler _stateHandler = null;
    [RequiredReference] private InputHandlingModule _inputHandlingModule = null;
    [RequiredReference] private LocomotionButtonsSettings _locomotionButtonsSettings = null;

    private Vector3 MovementVector { get { return _inputHandlingModule.CurrentInputSource.MovementVector; } }
    private float Speed { get { return _locomotionButtonsSettings.Speed; } }

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
        _transform.position = _transform.position + _transform.right * MovementVector.x * Speed * Time.deltaTime;
    }
}
