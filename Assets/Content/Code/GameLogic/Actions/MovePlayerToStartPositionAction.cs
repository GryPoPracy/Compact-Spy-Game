using ActionsSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToStartPositionAction : BaseAction
{
    public override void Perform(params object[] list)
    {
        PlayerCharacter.Instance.ReserToStartPosition();
    }
}
