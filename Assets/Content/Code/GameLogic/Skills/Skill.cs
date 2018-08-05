using ActionsSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Skills
{
    public class Skill : MonoBehaviour
    {
        [SerializeField] private ActionList _useSkillActionList = new ActionList();

        public void Perform()
        {
            _useSkillActionList.Perform();
        }
    }
}
