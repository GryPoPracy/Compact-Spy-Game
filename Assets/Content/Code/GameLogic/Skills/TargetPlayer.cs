using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : BaseSkillTargerProvider
{
    public override GameObject Target { get { return PlayerCharacter.Instance == null ? null : PlayerCharacter.Instance.gameObject; } }

    protected override IEnumerator SelectTargetCorutine()
    {
        yield return new WaitUntil(() => { return true; });
    }
}

