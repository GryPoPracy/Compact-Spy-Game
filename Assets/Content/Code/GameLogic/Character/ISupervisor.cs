using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    using Command = CommandProcesor.Command;
    public interface ISupervisor
    {
        Command CurrenntCommand { get; }
        void Consume();
    }
}