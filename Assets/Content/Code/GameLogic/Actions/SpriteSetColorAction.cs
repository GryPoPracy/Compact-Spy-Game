using ActionsSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSetColorAction : BaseAction
{
    [SerializeField] private SpriteColorSet _colorSet = new SpriteColorSet();

    public override void Perform(params object[] list)
    {
        _colorSet.SetColor();
    }
}
