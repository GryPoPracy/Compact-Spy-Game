using ActionsSystem;
using MainGameLogic.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGameLogic.Action
{
    public class ClearPlayerStateAction : BaseAction
    {
        public override void Perform(params object[] list)
        {
            PlayerCharacter.Instance.ClearPlayerState();
        }
    }
}