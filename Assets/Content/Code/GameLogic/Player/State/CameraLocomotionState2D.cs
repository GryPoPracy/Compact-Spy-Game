using BaseGameLogic.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocomotionState2D : IState, IOnLateUpdate
{
    [RequiredReference] private Transform _transform = null;
    private Transform PlayerTransform { get { return PlayerCharacter.Instance.transform; } }
    [RequiredReference] private CameraLocomotionState2DSettings _cameraLocomotionState2DSettings = null;

    public CameraLocomotionState2D() {}
    
    public void OnEnter() {}

    public void OnExit() {}

    public void OnLateUpdate()
    {
        Vector3 cameraPosition = _transform.position;
        cameraPosition.z = 0;
        float distance = Vector3.Distance(cameraPosition, PlayerTransform.position);
        float multimultiplier = _cameraLocomotionState2DSettings.DistanceSpeedMultiplier.Evaluate(distance);
        _transform.position = Vector3.MoveTowards(
            _transform.position, 
            PlayerTransform.position + _cameraLocomotionState2DSettings.CameraOffser, 
            _cameraLocomotionState2DSettings.Speed * Time.deltaTime * multimultiplier);
    }
}
