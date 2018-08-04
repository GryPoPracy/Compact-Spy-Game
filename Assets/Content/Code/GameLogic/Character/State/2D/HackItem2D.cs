using BaseGameLogic.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackItem2D : IState, IOnUpdate
{
    [RequiredReference] private Transform _transform = null;
    [RequiredReference] private StateHandler _stateHandler = null;
    [RequiredReference] private ProgressIndicator _progressIndicator = null;
    [RequiredReference] private Animator _animator = null;
    [RequiredReference] private CharacterAnimationHandler animationHandler = null; 

    private float _hackTime = 0;
    private Transform _locator = null;

    public HackItem2D(float hackTime, Transform locator)
    {
        _hackTime = hackTime;
        _locator = locator;
    }

    public void OnEnter()
    {
        _progressIndicator.Max = _hackTime;
        _transform.position = _locator.position;
        animationHandler.Hack.SetBool(_animator, true);
    }

    public void OnExit()
    {
        animationHandler.Hack.SetBool(_animator, false);
    }

    public void OnUpdate()
    {
        _progressIndicator.Current = (_hackTime -= Time.deltaTime);
        if (_progressIndicator.Current <= 0)
            _stateHandler.ExitState();
    }
}
