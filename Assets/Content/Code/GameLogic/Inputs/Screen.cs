using System.Collections;
using System.Collections.Generic;
using BaseGameLogic.Inputs;
using UnityEngine;

public class Screen : InputSource
{
    [SerializeField] private ScreenButtonInput _left = new ScreenButtonInput();
    [SerializeField] private ScreenButtonInput _right = new ScreenButtonInput();
    [SerializeField] private ScreenButtonInput _use = new ScreenButtonInput();

    public override ButtonInput Use { get { return _use; } }

    [SerializeField] private Vector3 _movementVector = Vector3.zero;
    public override Vector3 MovementVector
    {
        get
        {
            _movementVector.x = -_left.AnalogValueRaw + _right.AnalogValueRaw;
            return _movementVector;
        }
    }

}
