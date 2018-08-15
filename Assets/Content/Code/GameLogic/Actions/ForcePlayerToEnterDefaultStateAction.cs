using ActionsSystem;
using BaseGameLogic.States;
using BaseGameLogic.States.Providers;
using MainGameLogic.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGameLogic.Action
{
    public class ForcePlayerToEnterDefaultStateAction : BaseAction
    {
        public override void Perform(params object[] list)
        {
            PlayerCharacter.Instance.EnterDefaultState();
        }
    }
}