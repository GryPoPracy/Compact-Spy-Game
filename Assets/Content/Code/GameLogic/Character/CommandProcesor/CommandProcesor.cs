using BaseGameLogic.Inputs.Screen;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public partial class CommandProcesor : MonoBehaviour, ISupervisor
    {
        private Command _command = null;
        public Command CurrenntCommand { get { return _command; } }

        void Start()
        {
            if (ScreenInput.Instance != null)
            {
                ScreenInput.Instance.ObjectSelectedCallback.AddListener(Process);
                ScreenInput.Instance.ObjectSelected2DCallback.AddListener(Process);
            }
        }

        private void Process(ClickInfo2D arg0)
        {
            _command = new Command(arg0.WorldPosition, Vector3.zero, arg0.GameObject);
        }

        private void Process(Vector3 position, Vector3 arg1, Rigidbody arg2, GameObject arg3)
        {
            _command = new Command(position, arg3);
        }

        public void Consume()
        {
            _command = null;
        }
    }
}