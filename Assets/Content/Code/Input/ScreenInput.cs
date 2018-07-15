using UnityEngine;

using System.Collections.Generic;
using BaseGameLogic.Singleton;
using System;
using UnityEngine.Events;

namespace BaseGameLogic.Inputs.Screen
{
    public partial class ScreenInput : Singleton<ScreenInput>
    {
        [SerializeField] private CameraHandler _camera = new CameraHandler();
        [SerializeField] private List<ScreenClick> _clickHandlers = new List<ScreenClick>();
        [SerializeField] private LayerMask _detectObjectLayer = new LayerMask();

        public ObjectSelectedCallback ObjectSelectedCallback = new ObjectSelectedCallback();

        void Update()
        {
            for (int i = 0; i < _clickHandlers.Count; i++)
                if (_clickHandlers[i].IsPositive)
                    HandleClick(_clickHandlers[i].ScrennPosition);
        }

        public void HandleClick(Vector3 onScrennPosition)
        {
            Ray ray = _camera.Camera.ScreenPointToRay(onScrennPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _detectObjectLayer))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.green, 1f);
                ObjectSelectedCallback.Invoke(hit.point, hit.normal, hit.rigidbody, hit.collider.gameObject);
            }
        }
    }

    [Serializable] public class ObjectSelectedCallback : UnityEvent<Vector3, Vector3, Rigidbody, GameObject> {}
}