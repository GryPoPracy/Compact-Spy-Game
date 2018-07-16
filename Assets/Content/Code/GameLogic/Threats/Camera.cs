using UnityEngine;

using System.Collections;
using System.Collections.Generic;

namespace Threats
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] private Transform _pivot = null;
        [SerializeField] private float _speed = 5;
        [SerializeField] private Vector2 _angle = Vector2.zero;
        [SerializeField] private float v = .5f;
        [SerializeField] private bool _toMax = true;

        private void Update()
        {
            v += _speed * Time.deltaTime * (_toMax ? 1 : -1);
            if (v > 1)
                _toMax = false;
            if (v < 0)
                _toMax = true;

            Vector3 rotation = _pivot.transform.localRotation.eulerAngles;
            rotation.y = Mathf.Lerp(_angle.x, _angle.y, v);
            _pivot.transform.localRotation = Quaternion.Euler(rotation);
        }
    }
}
