using BaseGameLogic.Inputs.Screen;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class CommandProcesor : MonoBehaviour
    {
        public class Command
        {
            public readonly Vector3 Destination = Vector3.zero;
            public readonly GameObject GameObject = null;

            public Command(Vector3 destination, GameObject gameObject)
            {
                Destination = destination;
                GameObject = gameObject;
            }
        }

        public readonly Queue<Command> CommandQueue = new Queue<Command>();

        void Start()
        {
            if (ScreenInput.Instance != null)
                ScreenInput.Instance.ObjectSelectedCallback.AddListener(Process);
        }

        private void Process(Vector3 position, Vector3 arg1, Rigidbody arg2, GameObject arg3)
        {
            CommandQueue.Enqueue(new Command(position, arg3));
        }
    }
}