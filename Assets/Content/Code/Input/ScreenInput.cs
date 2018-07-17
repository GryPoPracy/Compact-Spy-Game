using UnityEngine;

using System.Collections.Generic;
using BaseGameLogic.Singleton;
using System;
using UnityEngine.Events;

namespace BaseGameLogic.Inputs.Screen
{

    public partial class ScreenInput : Singleton<ScreenInput>
    {
        private enum Mode { Physics2D, Physics3D }

        [SerializeField] private Mode _mode = Mode.Physics3D;

        [SerializeField] private CameraHandler _camera = new CameraHandler();
        [SerializeField] private List<ScreenClick> _clickHandlers = new List<ScreenClick>();
        [SerializeField] private LayerMask _detectObjectLayer = new LayerMask();

        [Obsolete("")]
        public ObjectSelectedCallback ObjectSelectedCallback = new ObjectSelectedCallback();
        public ObjectSelected2DCallback ObjectSelected2DCallback = new ObjectSelected2DCallback();
             
        void Update()
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
                        ObjectSelectedCallback.Invoke(hit.point, hit.normal, hit.rigidbody, hit.collider.gameObject);
                    }
                    break;
            }
        }
    }

    public class ClickInfo2D
    {
        public readonly Vector3 WorldPosition = Vector3.zero;
        public readonly Rigidbody2D Rigidbody2D = null;
        public readonly Collider2D Collider = null;
        public readonly GameObject GameObject = null;

        public ClickInfo2D(Vector3 worldPosition, Collider2D collider)
        {
            WorldPosition = worldPosition;
            if((Collider = collider) != null)
            {
                Rigidbody2D = collider.attachedRigidbody;
                GameObject = collider.gameObject;
            }
        }

        public ClickInfo2D(Vector3 worldPosition, Rigidbody2D rigidbody2D, GameObject gameObject)
        {
            WorldPosition = worldPosition;
            Rigidbody2D = rigidbody2D;
            GameObject = gameObject;
        }
    }

    public class ClickInfo
    {
        public readonly Vector3 WorldPosition = Vector3.zero;
        public readonly Vector3 HitPoint = Vector3.zero;
        public readonly Vector3 Normal = Vector3.zero;
        public readonly Rigidbody Rigidbody = null;
        public readonly GameObject GameObject = null;

        public ClickInfo(Vector3 worldPosition, Vector3 hitPoint, Vector3 normal, Rigidbody rigidbody, GameObject gameObject)
        {
            WorldPosition = worldPosition;
            HitPoint = hitPoint;
            Normal = normal;
            Rigidbody = rigidbody;
            GameObject = gameObject;
        }
    }

    [Obsolete()]
    [Serializable] public class ObjectSelectedCallback : UnityEvent<Vector3, Vector3, Rigidbody, GameObject> {}
    [Serializable] public class ObjectSelected2DCallback : UnityEvent<ClickInfo2D> {}

}