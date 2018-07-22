using BaseGameLogic.States;
using BaseGameLogic.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocomotionState2D : IState, IOnLateUpdate
{
    [RequiredReference] private Camera _camera = null;
    [RequiredReference] private Transform _transform = null;
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
        float x = _camera.orthographicSize * _camera.aspect;
        Vector3 cameraPosition = _transform.position;
        cameraPosition.z = 0;
        float distance = Vector3.Distance(cameraPosition, PlayerTransform.position);
        if(distance > _cameraLocomotionState2DSettings.TeleportDistance)
        {
            var position = PlayerTransform.position;
            position.z = _cameraLocomotionState2DSettings.CameraOffset.z;
            _transform.position = position;
        }

        float multimultiplier = _cameraLocomotionState2DSettings.DistanceSpeedMultiplier.Evaluate(distance);
        _transform.position = Vector3.MoveTowards(
            _transform.position, 
            PlayerTransform.position + _cameraLocomotionState2DSettings.CameraOffset, 
            _cameraLocomotionState2DSettings.Speed * Time.deltaTime * multimultiplier);
        if(_cameraLocomotionState2DSettings.UseBounds)
            constraint.ForceBoundaries();
    }
}
