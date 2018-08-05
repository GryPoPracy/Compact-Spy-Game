using UnityEngine;

using System.Collections.Generic;
using BaseGameLogic.Singleton;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace BaseGameLogic.Inputs.Screen
{

    public partial class ScreenInput : Singleton<ScreenInput>
    {
        private enum Mode { Physics2D, Physics3D }

        [SerializeField] private Mode _mode = Mode.Physics3D;

        [SerializeField] private CameraHandler _camera = new CameraHandler();
        [SerializeField] private List<ScreenClick> _clickHandlers = new List<ScreenClick>();
        [SerializeField] private LayerMask _detectObjectLayer = new LayerMask();

        public ObjectSelectedCallback ObjectSelectedCallback = new ObjectSelectedCallback();
        public ObjectSelected2DCallback ObjectSelected2DCallback = new ObjectSelected2DCallback();

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
                    ObjectSelected2DCallback.Invoke(new ClickInfo2D(worldPosition, collider));
                    break;

                case Mode.Physics3D:
                    worldPosition = _camera.Camera.ScreenToWorldPoint(onScrennPosition);
                    Ray ray = _camera.Camera.ScreenPointToRay(onScrennPosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, _detectObjectLayer))
                    {
                        Debug.DrawLine(ray.origin, hit.point, Color.green, 1f);
                        ObjectSelectedCallback.Invoke(new ClickInfo(hit));
                    }
                    break;
            }
        }
    }

    public class ClickInfo2D
    {
        public readonly Vector3 WorldPosition = Vector3.zero;
        public Rigidbody2D Rigidbody2D { get { return Collider.attachedRigidbody; } }
        public readonly Collider2D Collider = null;
        public GameObject GameObject { get { return Collider == null ? null : Collider.gameObject; } }

        public ClickInfo2D(Vector3 worldPosition, Collider2D collider)
        {
            WorldPosition = worldPosition;
            Collider = collider;
        }
    }

    public class ClickInfo
    {
        private RaycastHit hitInfo;
        public Vector3 WorldPosition = Vector3.zero;
        public Collider Collider { get { return hitInfo.collider; } }
        public Vector3 HitPoint { get { return hitInfo.point; } }
        public Vector3 Normal { get { return hitInfo.normal; } }
        public Rigidbody Rigidbody { get { return hitInfo.rigidbody; } }
        public GameObject GameObject { get { return hitInfo.collider.gameObject; } }

        public ClickInfo(RaycastHit hitInfo)
        {
            this.hitInfo = hitInfo;
        }
    }

    [Serializable] public class ObjectSelectedCallback : UnityEvent<ClickInfo> {}
    [Serializable] public class ObjectSelected2DCallback : UnityEvent<ClickInfo2D> {}

}