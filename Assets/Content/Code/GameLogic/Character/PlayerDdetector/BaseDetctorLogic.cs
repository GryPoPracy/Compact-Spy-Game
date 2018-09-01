using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDetctorLogic : MonoBehaviour
{
    public abstract float Detect(float detectionRate, LayerMask layerMask);
    public abstract void Clear();
}
