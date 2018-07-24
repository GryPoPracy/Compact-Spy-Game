using BaseGameLogic.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class EnemyController : MonoBehaviour, ISupervisor
    {
        private Command _currenntCommand = null;
        public Command CurrenntCommand { get { return _currenntCommand; } }

        [SerializeField] private Index _index = null;

        [SerializeField] private float _maxLeft = 0;
        [SerializeField] private float _maxRight = 0;

        private Path _path = null;

        public class Path
        {
            [SerializeField] private Vector3[] _points = null;

            public int Count { get { return _points.Length; } }

            public Path(Vector3 startPosition, float maxLeft, float maxRight, float leftBound, float rightBound)
            {
                _points = new Vector3[2];

                float left = startPosition.x - maxLeft < leftBound ? startPosition.x + leftBound : startPosition.x - maxLeft;
                float right = startPosition.x + rightBound > leftBound ? startPosition.x - rightBound : startPosition.x + rightBound;

                if (startPosition.x - maxLeft < leftBound)
                    _points[0] = new Vector3(leftBound, startPosition.y, startPosition.z);
                else
                    _points[0] = startPosition + (-Vector3.right * Mathf.Abs(left));

                if (startPosition.x + rightBound > leftBound)
                    _points[1] = new Vector3(rightBound, startPosition.y, startPosition.z);
                else
                    _points[1] = startPosition + (Vector3.right * Mathf.Abs(right));
            }

            public Path(Vector3 startPosition, float maxLeft, float maxRight)
            {
                _points = new Vector3[2];
                _points[0] = startPosition + (-Vector3.right * Mathf.Abs(maxLeft));
                _points[1] = startPosition + (Vector3.right * Mathf.Abs(maxRight));
            }

            public Vector3 this[int key]
            {
                get { return _points[key]; }
            }
        }

        public void Consume()
        {
            _currenntCommand = null;
        }

        private void Start()
        {
            _path = new Path(this.transform.position, _maxLeft, _maxRight, LevelInfo.Instance.LevelBounds.MinWidth, LevelInfo.Instance.LevelBounds.MaxWidth);
            _currenntCommand = new Command(_path[_index], Vector3.zero, null);
        }

        private void Update()
        {
            if(transform.position == _path[_index])
            {
                _index++;
                _currenntCommand = new Command(_path[_index], Vector3.zero, null);
            }
        }
    }
}
