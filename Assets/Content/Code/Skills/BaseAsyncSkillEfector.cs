using BaseGameLogic.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAsyncSkillEfector : BaseSkillEffector
{
    public enum EffectType { Overwrite, Stackable }
    [SerializeField] private EffectType _type = EffectType.Overwrite;

    public EffectType Type { get { return _type; } }

    [SerializeField] private ClassConstructor _effectConstructor = new ClassConstructor();

    public override void Effect(GameObject target)
    {
        var effectManager = target.GetComponentInChildren<SkillsEffectManager>();
        if (effectManager == null)
            effectManager = target.AddComponent<SkillsEffectManager>();
        object effect = _effectConstructor.CreateInstance();
        effectManager.ApplyEffect(target, (IEffect)effect, _type);
    }
}
