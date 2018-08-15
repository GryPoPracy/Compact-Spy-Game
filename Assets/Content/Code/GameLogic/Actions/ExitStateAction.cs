using ActionsSystem;
using BaseGameLogic.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGameLogic.Action
{
    public class ExitStateAction : BaseAction
    {
        public override void Perform(params object[] list)
        {
            var statHandler = SelectObjectForData<StateHandler>(list);
            statHandler.ExitState();
        }
    }
}
