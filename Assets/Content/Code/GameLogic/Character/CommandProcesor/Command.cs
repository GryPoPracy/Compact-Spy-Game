using System;
using UnityEngine;

namespace Character
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
}