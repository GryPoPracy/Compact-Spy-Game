using BaseGameLogic.LevelGeneration;
using BaseGameLogic.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CameraLocomotionState2DSettings : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    public float Speed { get { return _speed; } }

    [SerializeField] private Vector3 _cameraOffser = Vector3.zero;
    public Vector3 CameraOffset { get { return _cameraOffser; } }

    [SerializeField] private bool _useBounds = true;
    public bool UseBounds { get { return _useBounds; } }

    public OrthogtaphicCameraBounds Bounds { get { return LevelMetadata.Instance == null ? null : LevelMetadata.Instance.LevelBounds; } }
}
