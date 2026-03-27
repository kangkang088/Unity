using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson11_动画曲线控件_布局API
{
    public class Lesson11 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson11/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow<Lesson11>();
            window.titleContent = new GUIContent("EditorGUILayout Introduce Window");
            window.Show();
        }

        private AnimationCurve _animationCurve = new();
        private Vector2 _scrollPosition;

        private void OnGUI()
        {
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);

            _animationCurve = EditorGUILayout.CurveField("Animation Curve", _animationCurve);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Label1");
            EditorGUILayout.LabelField("Label2");
            EditorGUILayout.LabelField("Label3");
            EditorGUILayout.LabelField("Label4");
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginVertical();
            EditorGUILayout.LabelField("Label5");
            EditorGUILayout.LabelField("Label6");
            EditorGUILayout.LabelField("Label7");
            EditorGUILayout.LabelField("Label8");

            EditorGUILayout.EndVertical();

            EditorGUILayout.EndScrollView();
        }
    }
}