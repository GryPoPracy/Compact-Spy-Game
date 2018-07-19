using ActionsSystem;
using BaseGameLogic.States.Providers;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDefaultState : BaseAction
{
    public override void Perform(params object[] list)
    {
        var stateProvider = SelectObjectForData<GameObject>(list).GetComponent<BaseStateProvider>();
        stateProvider.EnterDefaultState();
    }
}
