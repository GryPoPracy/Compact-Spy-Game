using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionButtonsSettings : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    public float Speed { get { return _speed; } }
}
