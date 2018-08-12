using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillsEffectManager : MonoBehaviour
{
    [Serializable] private class EffectInfo
    {
        [SerializeField] private string _effectName = string.Empty;
        public string EffectName { get { return _effectName; } }
        public IEffect Effect { get; set; }

        public EffectInfo(IEffect effect)
        {
            Effect = effect;
            _effectName = Effect.GetType().Name;
        }

    }
        
    public void ApplyEffect(GameObject target, IEffect effect, BaseAsyncSkillEfector.EffectType type)
    {
        bool overrided = false;
        if (type == BaseAsyncSkillEfector.EffectType.Overwrite)
        {
            var effectInstance = _activeEffectList.FirstOrDefault(e => e.EffectName == effect.GetType().Name);
            var index = _activeEffectList.IndexOf(effectInstance);
            if (index > -1)
            {
                _activeEffectList[index] = new EffectInfo(effect);
                _activeEffectList[index].Effect.Activate(target);
                overrided = true;
            }
        }

        if (!overrided)
        {
            effect.Activate(target);
            _activeEffectList.Add(new EffectInfo(effect));
        }
    }

    [SerializeField] private List<EffectInfo> _activeEffectList = new List<EffectInfo>();

    private void Update()
    {
        for (int i = 0; i < _activeEffectList.Count; i++)
            if (_activeEffectList[i].Effect.Update(Time.deltaTime))
            {
                _activeEffectList[i].Effect.Deactivate();
                _activeEffectList.RemoveAt(i--);
            }
    }
}