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
        [SerializeField] private LayerMask layerMask = new LayerMask();
        [SerializeField] private SpriteRenderer spriteRenderer = null;
        [SerializeField] private float _detectionDistance = 2f;
        [SerializeField] private float _instantDetectionDistance = 1f;
        public DetectionRateUpdate DetectionRateUpdateCallback = new DetectionRateUpdate();
        [SerializeField, Range(0f, 1f)] private float _detection = 0;
        [SerializeField] private float _detectionRate = 1f;

        [SerializeField] private GlobalEventTrigger _playerDetectedEventTrigger = new GlobalEventTrigger();

        private void Awake()
        {
            DetectionRateUpdateCallback.Invoke(_detection);
        }

        private void Update()
        {
            var end = this.transform.position + (spriteRenderer.flipX ? -transform.right : transform.right) * _detectionDistance;

            RaycastHit2D hit2D = Physics2D.Linecast(this.transform.position, end, layerMask);

            IState state = null;
            if (hit2D)
            {
                state = GetComponent<StateHandler>().CurrentStateInterfaceHandler.CurrentState;
                if (!(state is HideState2D))
                {
                    Debug.LogFormat("I see {0}", hit2D.collider.name);
                    if (Vector3.Distance(hit2D.collider.transform.position, transform.position) < _instantDetectionDistance)
                        _playerDetectedEventTrigger.Trigger();
                }
            }
            _detection = Mathf.Clamp01(_detection += _detectionRate * Time.deltaTime * (hit2D && !(state is HideState2D) ? 1 : -1));
            if(_detection == 1f)
                _playerDetectedEventTrigger.Trigger();

            DetectionRateUpdateCallback.Invoke(_detection);
        }

        private void OnValidate()
        {
            _instantDetectionDistance = _instantDetectionDistance > _detectionDistance ? _detectionDistance : _instantDetectionDistance;
        }

        private void OnDrawGizmos()
        {
            var end = this.transform.position + (spriteRenderer.flipX ? -transform.right : transform.right) * _detectionDistance;
            var instantEnd = this.transform.position + (spriteRenderer.flipX ? -transform.right : transform.right) * _instantDetectionDistance;
            Debug.DrawLine(this.transform.position, end, Color.yellow);
            Debug.DrawLine(this.transform.position, instantEnd, Color.red);
        }
    }

    [Serializable] public class DetectionRateUpdate : UnityEvent<float> { };
}
