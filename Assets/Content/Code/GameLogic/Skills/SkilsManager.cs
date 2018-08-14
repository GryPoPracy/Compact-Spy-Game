using ActionsSystem;
using BaseGameLogic.Singleton;
using BaseGameLogic.States;
using BaseGameLogic.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Object = UnityEngine.Object;

namespace Skills
{
    public class SkilsManager : Singleton<SkilsManager>
    {
        [Serializable] public class SkillEffect
        {
            [SerializeField] private string _name = string.Empty;
            public string Name { get { return _name; } }

            [SerializeField] private float _skillEffectDuration = 0f;
            public float SkillEffectDuration { get { return _skillEffectDuration; } }

            [SerializeField] private ActionList _activateSkillAction = new ActionList();
            public ActionList ActivateSkillAction { get { return _activateSkillAction; } }
            
            [SerializeField] private ActionList _deactivateSkillAction = new ActionList();
            public ActionList DeactivateSkillAction { get { return _deactivateSkillAction; } }
            
        }

        [SerializeField] private SkillEffect[] _skills = null;
        private Dictionary<string, SkillEffect> skillsDictionary = new Dictionary<string, SkillEffect>();
        [SerializeField] private Object[] _data = null;


        protected override void Awake()
        {
            base.Awake();
            foreach(var skill in _skills)
                skillsDictionary.Add(skill.Name, skill);
        }

        public void PerformSkill(string name)
        {
            SkillEffect skill;
            if (skillsDictionary.TryGetValue(name, out skill))
                StartCoroutine(SkillEffectCorutine(skill));
        }

        private IEnumerator SkillEffectCorutine(SkillEffect skill)
        {
            skill.ActivateSkillAction.Perform();
            yield return new WaitForSeconds(skill.SkillEffectDuration);
            skill.DeactivateSkillAction.Perform();
        }
    }
}
