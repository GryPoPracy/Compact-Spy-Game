using ActionsSystem;
using BaseGameLogic.Utilities.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetColorAction : BaseAction
{
    [SerializeField] private UIColorSet _colorSeter = new UIColorSet();

    public override void Perform(params object[] list)
    {
        _colorSeter.SetColor();
    }
}
