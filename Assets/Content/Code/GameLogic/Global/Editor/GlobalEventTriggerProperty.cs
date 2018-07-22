﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(GlobalEventTrigger))]
public class GlobalEventTriggerProperty : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var globalEventManager = GameObject.FindObjectOfType<GlobalEventsManager>();
        if (globalEventManager == null)
            EditorGUI.LabelField(position, new GUIContent("There is no GlobalEventsManager on scene!"));
        else
        {
            if(globalEventManager.EventList.Count == 0)
                EditorGUI.LabelField(position, new GUIContent("No events added!"));
            else
            {
                var nameProperty = property.FindPropertyRelative("_eventName");
                List<string> eventNames = new List<string>();
                for (int i = 0; i < globalEventManager.EventList.Count; i++)
                {
                    eventNames.Add(globalEventManager.EventList[i].Name);
                }
                int index = eventNames.IndexOf(nameProperty.stringValue);
                index = EditorGUI.Popup(position, index, eventNames.ToArray());
                if(index >= 0)
                    nameProperty.stringValue = eventNames[index];
            }
        }
    }
}
