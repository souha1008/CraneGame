using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;  //‚±‚±‚Å“ü—Í•s‰Â‚É‚µ‚Ä‚¢‚é
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;   //Œ³‚É–ß‚µ‚Ä‚¨‚­
    }

}
