using BaseGameLogic.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDatabase : SingletonMonoBehaviour<SkillDatabase>
{
    [SerializeField] private List<Skill> skills = new List<Skill>();
    private Dictionary<string, Skill> skillsDictionary = new Dictionary<string, Skill>();
    protected override void Awake()
    {
        base.Awake();
        foreach (var item in skills)
            skillsDictionary.Add(item.name, item);
    }

    internal void UseSkill(string name, GameObject target)
    {
        Skill skill = null;
        if (skillsDictionary.TryGetValue(name, out skill))
            skill.Use(target);
    }
}

