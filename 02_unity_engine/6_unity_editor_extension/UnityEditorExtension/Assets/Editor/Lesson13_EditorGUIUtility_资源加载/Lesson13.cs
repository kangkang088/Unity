using UnityEditor;
using UnityEngine;

namespace Editor.Lesson13_EditorGUIUtility_资源加载
{
    public class Lesson13 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson13/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(Lesson13));
            window.titleContent = new GUIContent("EditorGUIUtility Introduce Window");
            window.Show();
        }

        private Texture _texture;
        private Texture _texture2;

        private void OnGUI()
        {
            _texture = (Texture)EditorGUILayout.ObjectField(_texture, typeof(Texture), false);

            if (GUILayout.Button("Load Editor Texture"))
            {
                _texture = EditorGUIUtility.Load("sample.png") as Texture;
                if (_texture)
                {
                    GUI.DrawTexture(new Rect(0, 50, 160, 90), _texture);
                }
            }

            _texture2 = (Texture)EditorGUILayout.ObjectField(_texture2, typeof(Texture), false);

            if (GUILayout.Button("Load Editor Texture"))
            {
                _texture2 = EditorGUIUtility.LoadRequired("sample2.png") as Texture;
                if (_texture2)
                {
                    GUI.DrawTexture(new Rect(0, 50, 160, 90), _texture2);
                }
            }
        }
    }
}