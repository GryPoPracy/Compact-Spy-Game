using BaseGameLogic.Inputs.Screen;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class CommandProcesor : MonoBehaviour
    {
        [Serializable] public class Command
        {
            public readonly Vector3 Destination = Vector3.zero;
            public readonly GameObject GameObject = null;

            public Command(Vector3 destination, GameObject gameObject)
            {
                Destination = destination;
                GameObject = gameObject;
            }
        }

        private Command _command = null;
        public Command CurrenntCommand { get { return _command; } }

        void Start()
        {
            if (ScreenInput.Instance != null)
                ScreenInput.Instance.ObjectSelectedCallback.AddListener(Process);
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