using UnityEditor;
using UnityEngine;

namespace Editor.Lesson14_EditorGUIUtility_搜索框查询_对象选中提示
{
    public class Lesson14 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson14/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(Lesson14));
            window.titleContent = new GUIContent("EditorGUIUtility Introduce Window");
            window.Show();
        }

        private Texture _texture;

        private void OnGUI()
        {
            if (GUILayout.Button("Open SearchBox"))
            {
                EditorGUIUtility.ShowObjectPicker<Texture>(null, false, "", 0);
            }

            if (Event.current.commandName == "ObjectSelectorUpdated")
            {
                _texture = EditorGUIUtility.GetObjectPickerObject() as Texture;
                if (_texture != null) Debug.Log(_texture.name);
            }
            else if (Event.current.commandName == "ObjectSelectorClosed")
            {
                _texture = EditorGUIUtility.GetObjectPickerObject() as Texture;
                if (_texture != null) Debug.Log("Window Closed");
            }

            if (GUILayout.Button("Highlight Selected"))
            {
                if (_texture != null)
                    EditorGUIUtility.PingObject(_texture);
            }
        }
    }
}