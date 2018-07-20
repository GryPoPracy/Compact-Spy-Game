using BaseGameLogic.States;
using BaseGameLogic.Utilities;
using Interactions;
using Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionState2D : IState, IOnUpdate, IOnSleep
{
    [RequiredReference] private Transform _transform = null;
    [RequiredReference] private Animator _animator = null;
    [RequiredReference] private SpriteRenderer _renderer = null;
    [RequiredReference] private ISupervisor _supervisor = null;
    [RequiredReference] private StateHandler _stateHandler = null;
    [RequiredReference] private CharacterAnimationHandler _characterAnimationHandler = null;
    [RequiredReference] private LocomotionState2DSettings _locomotionState2DSettings = null;

    private Vector3 _destination = Vector3.zero;
    private IInteraction _interaction = null;
    private Collider2D _collider = null;

    private Latch _flipLath = new Latch();

    public LocomotionState2D() {}

    public void OnEnter()
    {
        _destination = _transform.position;
    }

    public void OnExit() {}

    public void OnSleep()
    {
        _characterAnimationHandler.Run.SetBool(_animator, false);
    }

    public void OnUpdate()
    {
        HandleIntput();
        MoveHaracter();
        Interact();
    }

    private void Interact()
    {
        if (_locomotionState2DSettings.UseInteractions && _interaction != null && _collider.OverlapPoint(_locomotionState2DSettings.ColectPoint.position))
        {
            _interaction.Interact(_transform.gameObject, _stateHandler);
            _collider = null;
            _interaction = null;
        }
    }

    private void MoveHaracter()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _destination, _locomotionState2DSettings.Speed * Time.deltaTime);
        if (Vector3.Distance(_transform.position, _destination) <= 0)
            _characterAnimationHandler.Run.SetBool(_animator, false);
        else
            _characterAnimationHandler.Run.SetBool(_animator, true);

        if(_flipLath)
            _renderer.flipX = _transform.position.x > _destination.x;
    }

    private void HandleIntput()
    {
        if(_supervisor.CurrenntCommand != null)
        {
            if(_supervisor.CurrenntCommand.GameObject != null)
            {
                _collider = _supervisor.CurrenntCommand.GameObject.GetComponent<Collider2D>();
                _interaction = _supervisor.CurrenntCommand.GameObject.GetComponent<IInteraction>();
            }

            if (!_locomotionState2DSettings.MoveOnInteractionOnly || (_locomotionState2DSettings.MoveOnInteractionOnly && _interaction != null))
            {
                _destination.x = _supervisor.CurrenntCommand.WorldPosition.x;
                _flipLath.Reset();
            }

            _supervisor.Consume();
        }
    }
}
