using ActionsSystem;
using BaseGameLogic.States.Providers;
using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDefaultStateAction : BaseAction
{
    public override void Perform(params object[] list)
    {
        var stateProvider = SelectObjectForData<GameObject>(list).GetComponent<BaseStateProvider>();
        stateProvider.EnterDefaultState();
    }
}
