using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(CharacterAnimationHandler.AnimatorParametr))]
public class AnimatorParametrProperty : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var nameValue = property.FindPropertyRelative("_name");
        EditorGUI.PropertyField(position, nameValue, new GUIContent(string.Format("{0} parameter name: ", property.displayName)));
        property.FindPropertyRelative("_nameHash").intValue = Animator.StringToHash(nameValue.stringValue);
    }
}
