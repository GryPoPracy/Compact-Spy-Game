using BaseGameLogic.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputSource : BaseInputSource
{
    public abstract PhysicalInput Use { get; }

    public abstract PhysicalInput UseSkill0 { get; }
    public abstract PhysicalInput UseSkill1 { get; }
    public abstract PhysicalInput UseSkill2 { get; }
    public abstract PhysicalInput UseSkill3 { get; }
}
