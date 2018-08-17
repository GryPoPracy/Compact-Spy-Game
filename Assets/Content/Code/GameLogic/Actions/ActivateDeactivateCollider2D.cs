using ActionsSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGameLogic.Action
{
    public class ActivateDeactivateCollider2D : BaseAction
    {
        [SerializeField] private Collider2D _collider2D = null;
        [SerializeField] private bool _enable = false;

        public override void Perform(params object[] list)
        {
            if (_collider2D != null)
                _collider2D.enabled = _enable;
        }
    }
}