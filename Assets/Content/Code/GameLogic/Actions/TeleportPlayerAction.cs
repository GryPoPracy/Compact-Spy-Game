using ActionsSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerAction : BaseAction
{
    [SerializeField] Transform _destination = null;

    public override void Perform(params object[] list)
    {
        var objectToTeleport = SelectObjectForData<GameObject>(list);
        if (_destination != null && objectToTeleport != null)
            objectToTeleport.transform.position = _destination.position;
    }
}
