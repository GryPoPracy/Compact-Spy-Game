﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocomotionState2DSettings : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    public float Speed { get { return _speed; } }

    [SerializeField] private AnimationCurve _distanceSpeedMultiplier = new AnimationCurve();
    public AnimationCurve DistanceSpeedMultiplier { get { return _distanceSpeedMultiplier; } }

    [SerializeField] private Vector3 _cameraOffser = Vector3.zero;
    public Vector3 CameraOffset { get { return _cameraOffser; } }

    [SerializeField] private float _teleportDistance = 4f;
    public float TeleportDistance { get { return _teleportDistance; } }


}