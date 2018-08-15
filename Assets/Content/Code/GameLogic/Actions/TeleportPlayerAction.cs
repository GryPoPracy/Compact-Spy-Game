using ActionsSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGameLogic.Action
{
    public class TeleportPlayerAction : BaseAction
    {
        public Color GizmoColor = new Color(0, 0, 1, 1);
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
            Gizmos.color = GizmoColor;
            Vector3 position = Destination;
            Gizmos.DrawLine(position - Vector3.right * .145f, position + Vector3.right * .145f);
            Gizmos.DrawLine(position, position + Vector3.up * .25f);
        }
    }
}