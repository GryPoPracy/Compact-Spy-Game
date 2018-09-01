using ActionsSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGameLogic.Action
{
    public class TeleportPlayerAction : BaseAction
    {
        public Color GizmoColor = new Color(0, 0, 1, 1);
        [SerializeField] private Vector3 _destination = Vector3.up;
        public Vector3 Destination
        {
            get { return transform.TransformPoint(_destination); }
            set { _destination =  transform.InverseTransformPoint(value); }
        }

        public override void Perform(params object[] list)
        {
            var objectToTeleport = SelectObjectForData<GameObject>(list);
            if (Destination != null && objectToTeleport != null)
                objectToTeleport.transform.position = Destination;
        }

        private void OnDrawGizmos()
        {
            System.Action<Vector3, Color> drawMarker = (Vector3 pos, Color color) =>
            {
                Gizmos.DrawLine(pos - Vector3.forward, pos + Vector3.forward);
                Gizmos.DrawLine(pos - Vector3.right, pos + Vector3.right);
                Gizmos.DrawLine(pos, pos + Vector3.up);
            };

            drawMarker(transform.position, GizmoColor);
            drawMarker(Destination, GizmoColor);
        }
    }
}