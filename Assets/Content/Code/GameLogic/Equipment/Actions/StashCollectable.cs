using ActionsSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Equipment
{
    public class StashCollectable : BaseAction
    {
        public override void Perform(params object[] list)
        {
            EquipmentManager.Instance.Stash();
        }
    }
}