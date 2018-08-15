using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEffect : IEffect
{
    public void Activate(GameObject target)
    {
    }

    public void Deactivate()
    {
    }

    public bool Update(float deltaTime)
    {
        return false;
    }
}
