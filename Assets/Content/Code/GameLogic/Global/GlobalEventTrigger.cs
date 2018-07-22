﻿using System;
using UnityEngine;

[Serializable] public class GlobalEventTrigger
{
    [SerializeField] private string _eventName = string.Empty;

    public void Trigger(params object[] data)
    {
        if (GlobalEventsManager.Instance != null)
            GlobalEventsManager.Instance.TriggerEvent(_eventName, data);
    }
}
