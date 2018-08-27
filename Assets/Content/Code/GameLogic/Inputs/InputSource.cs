using BaseGameLogic.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputSource : BaseInputSource
{
    public abstract ButtonInput Use { get; }
}
