using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public interface ISupervisor
    {
        Command CurrenntCommand { get; }
        void Consume();
    }
}