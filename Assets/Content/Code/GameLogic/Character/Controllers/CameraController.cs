using BaseGameLogic.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGameLogic.Characters
{
    [RequireComponent(typeof(CameraLocomotionState2DSettings))]
    public class CameraController : SingletonMonoBehaviour<CameraController>
    {
        [SerializeField] private CameraLocomotionState2DSettings _settings = null;
        [SerializeField] private bool _parentToPlayer = true;

        protected override void Awake()
        {
            base.Awake();
            if(_parentToPlayer)
                this.transform.SetParent(PlayerCharacter.Instance.transform);
        }

        private void Reset()
        {
            _settings = GetComponent<CameraLocomotionState2DSettings>();
        }
    }
}