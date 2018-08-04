using BaseGameLogic.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.States
{
    public class HideState2D : IState, IOnUpdate
    {
        [RequiredReference] private Transform _transform = null;
        [RequiredReference] private StateHandler _stateHandler = null;
        [RequiredReference] private CommandProcesor _procesor = null;
        [RequiredReference] private SpriteRenderer _characterSpriteRenderer = null;

        private Transform _hideout = null;
        private SpriteRenderer _hideoutSpriteRenderer = null;
        private int _sortingOrder = 0;
        private Vector3 _position = Vector3.zero;

        public HideState2D(Transform hideout, SpriteRenderer hideoutSpriteRenderer)
        {
            _hideout = hideout;
            _hideoutSpriteRenderer = hideoutSpriteRenderer;
        }

        public void OnEnter()
        {
            _position = _transform.position;
            _position.x = _hideout.position.x;
            _transform.position = _hideout.position;
            _sortingOrder = _hideoutSpriteRenderer.sortingOrder;
            _hideoutSpriteRenderer.sortingOrder = _characterSpriteRenderer.sortingOrder + 1;
        }

        public void OnExit()
        {
            _hideoutSpriteRenderer.sortingOrder = _sortingOrder;
            _transform.position = _position;
        }

        public void OnUpdate()
        {
            if(_procesor.CurrenntCommand != null)
            {
                _stateHandler.ExitState();
            }
        }
    }
}