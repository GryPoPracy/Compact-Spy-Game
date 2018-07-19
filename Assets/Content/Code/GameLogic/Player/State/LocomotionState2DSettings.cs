using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionState2DSettings : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    public float Speed { get { return _speed; } }

    [SerializeField] private bool _moveOnInteractionOnly = true;
    public bool MoveOnInteractionOnly { get { return _moveOnInteractionOnly; } }

    [SerializeField] private Transform _colectPoint = null;
    public Transform ColectPoint { get { return _colectPoint; } }
}
