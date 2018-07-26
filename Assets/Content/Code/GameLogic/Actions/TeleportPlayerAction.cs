using ActionsSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerAction : BaseAction
{
    [SerializeField] private Vector3 _destination = Vector3.zero;
    public Vector3 Destination
    {
        get { return _destination; }
        set { _destination = value; }
    }

    public override void Perform(params object[] list)
    {
        var objectToTeleport = SelectObjectForData<GameObject>(list);
        if (Destination != null && objectToTeleport != null)
            objectToTeleport.transform.position = Destination;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 position = Destination;
        Gizmos.DrawLine(position - Vector3.right * .145f, position + Vector3.right * .145f);
        Gizmos.DrawLine(position, position + Vector3.up * .25f);
    }
}
