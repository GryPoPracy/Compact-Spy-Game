using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public interface IInteraction
    {
        void Interact(params object[] data);
    }
}
