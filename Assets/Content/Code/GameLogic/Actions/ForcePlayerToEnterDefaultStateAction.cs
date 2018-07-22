using ActionsSystem;
using BaseGameLogic.States;
using BaseGameLogic.States.Providers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlayerToEnterDefaultStateAction : BaseAction
{
    public override void Perform(params object[] list)
    {
        PlayerCharacter.Instance.EnterDefaultState();
    }
}
