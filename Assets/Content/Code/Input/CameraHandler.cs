using UnityEngine;

using System;

namespace BaseGameLogic.Inputs.Screen
{
    [Serializable]
    public class CameraHandler
    {
        [SerializeField] private Camera _camera = null;

        public Camera Camera
        {
            get
            {
#if UNITY_EDITOR
                if (_camera == null)
                    Debug.LogWarning("You didn't select any camera. Default one is used.");
#endif
                return _camera == null ? Camera.main : _camera;
            }
        }

        public static implicit operator Camera(CameraHandler handler)
        {
            return handler.Camera;
        }
    }
}