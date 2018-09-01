using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MainGameLogic.Action
{
    [CustomEditor(typeof(TeleportPlayerAction))]
    public class TeleportPlayerActionEditor : Editor
    {
        TeleportPlayerAction item = null;

        private void OnEnable()
        {
            item = target as TeleportPlayerAction;    
        }

        private void OnSceneGUI()
        {
            item.Destination = Handles.PositionHandle(item.Destination, Quaternion.identity);
        }
    }
}