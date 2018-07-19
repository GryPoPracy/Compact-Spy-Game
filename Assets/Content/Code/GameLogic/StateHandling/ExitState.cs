using ActionsSystem;
using BaseGameLogic.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitState : BaseAction
{
    public override void Perform(params object[] list)
    {
        var statHandler = SelectObjectForData<StateHandler>(list);
        statHandler.ExitState();
    }
}
