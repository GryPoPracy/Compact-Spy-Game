using UnityEngine;

using System.Collections.Generic;
using BaseGameLogic.Singleton;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace BaseGameLogic.Inputs.Screen
{

    public partial class ScreenInput : SingletonMonoBehaviour<ScreenInput>
    {
        private enum Mode { Physics2D, Physics3D }

        [SerializeField] private Mode _mode = Mode.Physics3D;

        [SerializeField] private CameraHandler _camera = new CameraHandler();
        [SerializeField] private List<ScreenClick> _clickHandlers = new List<ScreenClick>();
        [SerializeField] private LayerMask _detectObjectLayer = new LayerMask();

        public ObjectSelectedCallback ObjectSelectedCallback = new ObjectSelectedCallback();

        private void Update()
        {
            for (int i = 0; i < _clickHandlers.Count; i++)
                if (_clickHandlers[i].IsPositive)
                    HandleClick(_clickHandlers[i].ScrennPosition);
        }

        public void HandleClick(Vector3 onScrennPosition)
        {
            Vector3 worldPosition = Vector3.zero;

            switch (_mode)
            {
                case Mode.Physics2D:
                    worldPosition = _camera.Camera.ScreenToWorldPoint(onScrennPosition);
                    var collider =  Physics2D.OverlapPoint(worldPosition);
                    ObjectSelectedCallback.Invoke(new ClickInfo2D(worldPosition, collider));
                    break;

                case Mode.Physics3D:
                    worldPosition = _camera.Camera.ScreenToWorldPoint(new Vector3(onScrennPosition.x, onScrennPosition.y, Mathf.Abs(_camera.Camera.transform.position.z)));
                    Ray ray = _camera.Camera.ScreenPointToRay(onScrennPosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, _detectObjectLayer))
                    {
                        worldPosition = hit.point;
                        Debug.DrawLine(ray.origin, hit.point, Color.green, 1f);
                    }
                    ObjectSelectedCallback.Invoke(new ClickInfo(worldPosition, hit));
                    break;
            }
            Debug.LogFormat("On screen position: {0}.", onScrennPosition);
            Debug.LogFormat("World position: {0}.", worldPosition);
        }
    }

    public abstract class BaseClickInfo
    {
        public readonly Vector3 WorldPosition = Vector3.zero;

        public abstract GameObject GameObject { get; }

        protected BaseClickInfo(Vector3 worldPosition)
        {
            WorldPosition = worldPosition;
        }
    }

    public class ClickInfo2D : BaseClickInfo
    {
        public Rigidbody2D Rigidbody2D { get { return Collider.attachedRigidbody; } }
        public readonly Collider2D Collider = null;
        public override GameObject GameObject { get { return Collider == null ? null : Collider.gameObject; } }

        public ClickInfo2D(Vector3 worldPosition, Collider2D collider) : base(worldPosition)
        {
            Collider = collider;
        }
    }

    public class ClickInfo : BaseClickInfo
    {
        private RaycastHit hitInfo;
        public Collider Collider { get { return hitInfo.collider; } }
        public Vector3 HitPoint { get { return hitInfo.point; } }
        public Vector3 Normal { get { return hitInfo.normal; } }
        public Rigidbody Rigidbody { get { return hitInfo.rigidbody; } }
        public override GameObject GameObject { get { return hitInfo.collider == null ? null : hitInfo.collider.gameObject; } }

        public ClickInfo(Vector3 wordPosition,  RaycastHit hitInfo) :base (wordPosition)
        {
            this.hitInfo = hitInfo;
        }
    }

    [Serializable] public class ObjectSelectedCallback : UnityEvent<BaseClickInfo> {}
}