using System;
using Lesson24_Inspector_自定义属性的自定义显示;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson24_Inspector_自定义属性的自定义显示
{
    [CustomEditor(typeof(Lesson24))]
    public class Lesson24Editor : UnityEditor.Editor
    {
        private SerializedProperty _customProperty;

        private SerializedProperty _i;
        private SerializedProperty _f;

        private void OnEnable()
        {
            _customProperty = serializedObject.FindProperty("customProperty");

            // _i = _customProperty.FindPropertyRelative("i");
            // _f = _customProperty.FindPropertyRelative("f");
            _i = serializedObject.FindProperty("customProperty.i");
            _f = serializedObject.FindProperty("customProperty.f");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_customProperty, new GUIContent("Custom Property Default Draw"));

            _i.intValue = EditorGUILayout.IntField(new GUIContent("Custom Draw I"), _i.intValue);
            _f.floatValue = EditorGUILayout.FloatField(new GUIContent("Custom Draw F"), _f.floatValue);

            serializedObject.ApplyModifiedProperties();
        }
    }
}