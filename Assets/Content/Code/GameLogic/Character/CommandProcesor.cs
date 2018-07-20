using BaseGameLogic.Inputs.Screen;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CommandProcesor : MonoBehaviour, ISupervisor
    {
        [Serializable] public class Command
        {
            public Vector3 WorldPosition = Vector3.zero;
            public Vector3 HitPosition = Vector3.zero;
            public GameObject GameObject = null;

            public Command(Vector3 destination, GameObject gameObject)
            {
                HitPosition = destination;
                GameObject = gameObject;
            }

            public Command(Vector3 worldPosition, Vector3 destination, GameObject gameObject)
            {
                WorldPosition = worldPosition;
                GameObject = gameObject;
            }
        }

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