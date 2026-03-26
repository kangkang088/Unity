using UnityEditor;
using UnityEngine;

namespace Editor.Lesson4_EditorGUILayout_文本_层级_标签_颜色
{
    public class Lesson4 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson4/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow<Lesson4>();
            window.titleContent = new GUIContent("EditorGUILayout Introduce Window");
            window.Show();
        }

        private int _layer;
        private string _tag;
        private Color _color;

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Lesson4", "Test Content", EditorStyles.boldLabel);

            _layer = EditorGUILayout.LayerField("Layer Choice", _layer);

            _tag = EditorGUILayout.TagField("Tag Choice", _tag);

            _color = EditorGUILayout.ColorField(new GUIContent("Color Choice"), _color, true, true, true);
        }
    }
}