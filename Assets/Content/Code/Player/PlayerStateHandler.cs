using BaseGameLogic.States;
using BaseGameLogic.States.Providers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateHandler : BaseStateProvider
{
    public override IState DefaultState
    {
        get
        {
            return new LocomotionState();
        }
    }
}
