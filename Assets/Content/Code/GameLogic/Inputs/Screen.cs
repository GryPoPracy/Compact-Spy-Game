using System.Collections;
using System.Collections.Generic;
using BaseGameLogic.Inputs;
using UnityEngine;

public class Screen : InputSource
{
    [SerializeField] private ScreenButtonInput _left = new ScreenButtonInput();
    [SerializeField] private ScreenButtonInput _right = new ScreenButtonInput();
    [SerializeField] private ScreenButtonInput _use = new ScreenButtonInput();

    [SerializeField] private ScreenButtonInput _useSkill0 = new ScreenButtonInput();
    [SerializeField] private ScreenButtonInput _useSkill1 = new ScreenButtonInput();
    [SerializeField] private ScreenButtonInput _useSkill2 = new ScreenButtonInput();
    [SerializeField] private ScreenButtonInput _useSkill3 = new ScreenButtonInput();


    public override PhysicalInput Use { get { return _use; } }

    [SerializeField] private Vector3 _movementVector = Vector3.zero;
    public override Vector3 MovementVector
    {
        get
        {
            _movementVector.x = -_left.AnalogValueRaw + _right.AnalogValueRaw;
            return _movementVector;
        }
    }

    public override PhysicalInput UseSkill0 { get { return _useSkill0; } }

    public override PhysicalInput UseSkill1 { get { return _useSkill1; } }

    public override PhysicalInput UseSkill2 { get { return _useSkill2; } }

    public override PhysicalInput UseSkill3 { get { return _useSkill3; } }

    [SerializeField] private GameObject _canvasObject = null;
    [SerializeField] private bool _canvasStatus = true;

    protected override void Awake()
    {
        base.Awake();
        _canvasObject.SetActive(_canvasStatus);
    }
}
