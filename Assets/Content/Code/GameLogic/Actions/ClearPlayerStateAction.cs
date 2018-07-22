using ActionsSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPlayerStateAction : BaseAction
{
    public override void Perform(params object[] list)
    {
        PlayerCharacter.Instance.ClearPlayerState();
    }
}
