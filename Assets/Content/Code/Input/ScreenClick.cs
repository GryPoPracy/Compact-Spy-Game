using UnityEngine;

using System;

namespace BaseGameLogic.Inputs.Screen
{
    [Serializable]
    public abstract class ScreenClick : MonoBehaviour
    {
        public abstract bool IsPositive { get; }
        public abstract Vector3 ScrennPosition { get; }
    }
}