using System.Collections;
using System.Collections.Generic;
using BaseGameLogic.Inputs;
using UnityEngine;

public class Keyboard : InputSource
{
    [SerializeField] private ButtonInput _left = new ButtonInput(KeyCode.LeftArrow);
    [SerializeField] private ButtonInput _right = new ButtonInput(KeyCode.RightArrow);

    [SerializeField] private Vector3 _movementVector = Vector3.zero;
    public override Vector3 MovementVector
    {
        get
        {
            _movementVector.x = -_left.AnalogValueRaw + _right.AnalogValueRaw;
            return _movementVector;
        }
    }

    [SerializeField] private ButtonInput _use = new ButtonInput(KeyCode.Space);
    public override ButtonInput Use { get { return _use; } }

}
