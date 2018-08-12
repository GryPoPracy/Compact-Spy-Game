using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkillTargerProvider : MonoBehaviour
{
    public abstract GameObject Target { get; }

    protected abstract IEnumerator SelectTargetCorutine();

    protected IEnumerator UseSkillCorutine(string name)
    {
        yield return SelectTargetCorutine();
        SkillDatabase.Instance.UseSkill(name, Target);
    }

    public void UseSkillWithTarget(string name)
    {
        StartCoroutine(UseSkillCorutine(name));
    }
}
