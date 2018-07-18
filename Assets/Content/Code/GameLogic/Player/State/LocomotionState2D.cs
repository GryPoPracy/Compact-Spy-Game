﻿using BaseGameLogic.States;
using Interactions;
using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionState2D : IState, IOnUpdate, IOnSleep
{
    [RequiredReference] private Transform _transform = null;
    [RequiredReference] private Animator _animator = null;
    [RequiredReference] private SpriteRenderer _renderer = null;
    [RequiredReference] private CommandProcesor _commandProcesor = null;
    [RequiredReference] private StateHandler _stateHandler = null;
    [RequiredReference] private CharacterAnimationHandler _characterAnimationHandler = null;

    private float _speed = 3;
    private bool _moveOnInteractionOnly = false;
    private Transform _collectPoint = null;

    private Vector3 _destination = Vector3.zero;
    private IInteraction _interaction = null;
    private Collider2D _collider = null;

    public LocomotionState2D(float speed, bool moveOnInteractionOnly, Transform colectPoint)
    {
        _speed = speed;
        _collectPoint = colectPoint;
        _moveOnInteractionOnly = moveOnInteractionOnly;
    }

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
        if (_interaction != null && _collider.OverlapPoint(_collectPoint.position))
        {
            _interaction.Interact(_stateHandler);
            _collider = null;
            _interaction = null;
        }
    }

    private void MoveHaracter()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _destination, _speed * Time.deltaTime);
        if (Vector3.Distance(_transform.position, _destination) <= 0)
            _characterAnimationHandler.Run.SetBool(_animator, false);
    }

    private void HandleIntput()
    {
        if(_commandProcesor.CurrenntCommand != null)
        {
            if(_commandProcesor.CurrenntCommand.GameObject != null)
            {
                _collider = _commandProcesor.CurrenntCommand.GameObject.GetComponent<Collider2D>();
                _interaction = _commandProcesor.CurrenntCommand.GameObject.GetComponent<IInteraction>();
            }

            if(!_moveOnInteractionOnly || (_moveOnInteractionOnly && _interaction != null))
            {
                _renderer.flipX = _transform.position.x > _commandProcesor.CurrenntCommand.WorldPosition.x;
                _destination.x = _commandProcesor.CurrenntCommand.WorldPosition.x;
                _characterAnimationHandler.Run.SetBool(_animator, true);
            }

            _commandProcesor.Consume();
        }
    }
}
