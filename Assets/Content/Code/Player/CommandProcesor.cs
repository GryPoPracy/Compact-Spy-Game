using BaseGameLogic.Inputs.Screen;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcesor : MonoBehaviour
{
    public class Command
    {
        private Vector3 _destination = Vector3.zero;
        public Vector3 Destination { get { return _destination; } }

        public Command(Vector3 destination)
        {
            _destination = destination;
        }
    }

    public readonly Queue<Command> CommandQueue = new Queue<Command>();

	void Start ()
    {
        if(ScreenInput.Instance != null)
            ScreenInput.Instance.ObjectSelectedCallback.AddListener(Process);
	}

    private void Process(Vector3 position, Vector3 arg1, Rigidbody arg2, GameObject arg3)
    {
        CommandQueue.Enqueue(new Command(position));
    }
}
