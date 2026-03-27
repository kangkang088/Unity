using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson17_EditorGUIUtility_绘制色板_绘制曲线
{
    public class Lesson17 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson17/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(Lesson17));
            window.titleContent = new GUIContent("EditorGUIUtility Introduce Window");
            window.Show();
        }

        private Color _color;
        private AnimationCurve _curve = new();

        private void OnGUI()
        {
            _color = EditorGUILayout.ColorField(new GUIContent("Selected Color"), _color, true, true, true);
            EditorGUIUtility.DrawColorSwatch(new Rect(1080, 30, 20, 20), Color.blue);

            _curve = EditorGUILayout.CurveField(new GUIContent("Animation Curve"), _curve);
            EditorGUIUtility.DrawCurveSwatch(new Rect(100, 50, 200, 200), _curve, null, Color.red, Color.black);
        }
    }
}