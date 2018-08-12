using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] private List<BaseSkillEffector> _efectors = new List<BaseSkillEffector>();

    public void Use(GameObject target)
    {
        for (int i = 0; i < _efectors.Count; i++)
            _efectors[i].Effect(target);
    }
}
