using BaseGameLogic.States;
using BaseGameLogic.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocomotionState2D : IState, IOnLateUpdate
{
    [RequiredReference] private Camera _camera = null;
    private Transform PlayerTransform { get { return PlayerCharacter.Instance.transform; } }
    [RequiredReference] private CameraLocomotionState2DSettings _cameraLocomotionState2DSettings = null;

    private OrthogtaphicCameraBoundsConstraint constraint = null;

    public CameraLocomotionState2D() {}
    
    public void OnEnter()
    {
        constraint = new OrthogtaphicCameraBoundsConstraint(_cameraLocomotionState2DSettings.Bounds, _camera);
    }

    public void OnExit() {}

    public void OnLateUpdate()
    {
        _camera.transform.position = Vector3.MoveTowards(
            _camera.transform.position, 
            PlayerTransform.position + _cameraLocomotionState2DSettings.CameraOffset, 
            _cameraLocomotionState2DSettings.Speed * Time.deltaTime);

        if (_cameraLocomotionState2DSettings.UseBounds)
            constraint.ForceBoundaries();
    }
}
