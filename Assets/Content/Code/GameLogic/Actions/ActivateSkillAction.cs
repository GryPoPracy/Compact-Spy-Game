using ActionsSystem;
using Skills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSkillAction : BaseAction
{
    [SerializeField] private string _name = string.Empty;

    public override void Perform(params object[] list)
    {
        SkilsManager.Instance.PerformSkill(_name);
    }
}
