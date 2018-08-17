using ActionsSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGameLogic.Characters.Actions
{
    public class DisableEnablePlayerColliderAction : BaseAction
    {
        private Collider2D _collider = null;
        [SerializeField] private bool _enable = false;
        public override void Perform(params object[] list)
        {
            if (_collider == null)
                _collider = PlayerCharacter.Instance.GetComponentInChildren<Collider2D>();

            _collider.enabled = _enable;
        }
    }
}