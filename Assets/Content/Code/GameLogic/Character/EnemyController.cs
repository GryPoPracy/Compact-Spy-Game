using BaseGameLogic.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    using Command = CommandProcesor.Command;
    public class EnemyController : MonoBehaviour, ISupervisor
    {
        private Command _currenntCommand = null;
        public Command CurrenntCommand { get { return _currenntCommand; } }

        [SerializeField] private Index _index = null;
        [SerializeField] private Transform[] points = null;

        public void Consume()
        {
            _currenntCommand = null;
        }

        private void Start()
        {
            _currenntCommand = new CommandProcesor.Command(points[_index].position, Vector3.zero, null);
        }

        private void Update()
        {
            if(transform.position == points[_index].position)
            {
                _index++;
                _currenntCommand = new CommandProcesor.Command(points[_index].position, Vector3.zero, null);
            }
        }

        private void OnValidate()
        {
            _index.Count = points.Length;
        }
    }
}
