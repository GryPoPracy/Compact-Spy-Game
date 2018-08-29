using BaseGameLogic.States;
using BaseGameLogic.Utilities;
using Character.States;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    public class PlayerDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask = new LayerMask();
        public DetectionRateUpdate DetectionRateUpdateCallback = new DetectionRateUpdate();
        [SerializeField, Range(0f, 1f)] private float _detection = 0;
        [SerializeField] private float _detectionRate = 1f;
        [SerializeField] private BaseDetctorLogic _detctorLogic;
        [SerializeField] private GlobalEventTrigger _playerDetectedEventTrigger = new GlobalEventTrigger();

        private void Awake()
        {
            DetectionRateUpdateCallback.Invoke(_detection);
            if (_detctorLogic == null)
                enabled = false;
        }

        private void Update()
        {
            _detection = _detctorLogic.Detect(_detectionRate, _layerMask);
        }
    }

    [Serializable] public class DetectionRateUpdate : UnityEvent<float> {};
}
