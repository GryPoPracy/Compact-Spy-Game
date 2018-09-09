using System.Collections;
using System.Collections.Generic;
using BaseGameLogic.Inputs;
using UnityEngine;

public class Keyboard : InputSource
{
    [SerializeField] private ButtonInput _left = new ButtonInput(KeyCode.LeftArrow);
    [SerializeField] private ButtonInput _right = new ButtonInput(KeyCode.RightArrow);

    [SerializeField] private ButtonInput _useSkill0 = new ButtonInput(KeyCode.Alpha1);
    [SerializeField] private ButtonInput _useSkill1 = new ButtonInput(KeyCode.Alpha2);
    [SerializeField] private ButtonInput _useSkill2 = new ButtonInput(KeyCode.Alpha3);
    [SerializeField] private ButtonInput _useSkill3 = new ButtonInput(KeyCode.Alpha4);


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
    public override PhysicalInput Use { get { return _use; } }

    public override PhysicalInput UseSkill0 { get { return _useSkill0; } }

    public override PhysicalInput UseSkill1 { get { return _useSkill1; } }

    public override PhysicalInput UseSkill2 { get { return _useSkill2; } }

    public override PhysicalInput UseSkill3 { get { return _useSkill3; } }
}
