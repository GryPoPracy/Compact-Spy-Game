using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public interface IInteraction
    {
        void Detected();
        void Interact(params object[] data);
        void Leave();
    }
}
