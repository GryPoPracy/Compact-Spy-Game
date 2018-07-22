using ActionsSystem;
using BaseGameLogic.States;
using Character.States;
using Equipment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    public class PlayerDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask = new LayerMask();
        [SerializeField] private SpriteRenderer spriteRenderer = null;
        [SerializeField] private float _detectionDistance = 2f;
        [SerializeField] private float _instantDetectionDistance = 1f;
        public DetectionRateUpdate DetectionRateUpdateCallback = new DetectionRateUpdate();
        [SerializeField, Range(0f, 1f)] private float _detection = 0;
        [SerializeField] private float _detectionRate = 1f;

        private void Awake()
        {
            DetectionRateUpdateCallback.Invoke(_detection);
        }

        private void Update()
        {
            var end = this.transform.position + (spriteRenderer.flipX ? -transform.right : transform.right) * _detectionDistance;
            RaycastHit2D hit2D = Physics2D.Linecast(this.transform.position, end, layerMask);
            Debug.DrawLine(this.transform.position, end);
            IState state = null;
            if (hit2D)
            {
                state = GetComponent<StateHandler>().CurrentStateInterfaceHandler.CurrentState;
                if (!(state is HideState2D))
                {
                    Debug.LogFormat("I see {0}", hit2D.collider.name);
                    if (Vector3.Distance(hit2D.collider.transform.position, transform.position) < _instantDetectionDistance)
                        GlobalEventsManager.Instance.PlayerDetected();
                }
            }
            _detection = Mathf.Clamp01(_detection += _detectionRate * Time.deltaTime * (hit2D && !(state is HideState2D) ? 1 : -1));
            if(_detection == 1f)
                GlobalEventsManager.Instance.PlayerDetected();

            DetectionRateUpdateCallback.Invoke(_detection);
        }

        private void OnValidate()
        {
            _instantDetectionDistance = _instantDetectionDistance > _detectionDistance ? _detectionDistance : _instantDetectionDistance;
        }
    }

    [Serializable] public class DetectionRateUpdate : UnityEvent<float> { };
}
