using UnityEditor;
using UnityEngine;

namespace Editor.Lesson10_EditorGUILayout_帮助框_垂直间隔控件
{
    public class Lesson10 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson10/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow<Lesson10>();
            window.titleContent = new GUIContent("EditorGUILayout Introduce Window");
            window.Show();
        }

        private bool _isFoldOut;

        private void OnGUI()
        {
            _isFoldOut = EditorGUILayout.BeginFoldoutHeaderGroup(_isFoldOut, "Fold Group");
            if (_isFoldOut)
            {
                EditorGUILayout.HelpBox("Simple tip", MessageType.None);
                EditorGUILayout.Space(10);
                EditorGUILayout.HelpBox("! tip", MessageType.Info);
                EditorGUILayout.Space(10);
                EditorGUILayout.HelpBox("Warning tip", MessageType.Warning);
                EditorGUILayout.Space(10);
                EditorGUILayout.HelpBox("Error tip", MessageType.Error);   
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
    }
}
