using UnityEngine;
using UnityEditor;

using System.Collections;
using System.Collections.Generic;

namespace BaseGameLogic.Inputs.Screen
{
    [CustomPropertyDrawer(typeof(CameraHandler))]
    public class CameraHandlerProperty : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property.FindPropertyRelative("_camera"), new GUIContent("Camera"));
        }
    }
}