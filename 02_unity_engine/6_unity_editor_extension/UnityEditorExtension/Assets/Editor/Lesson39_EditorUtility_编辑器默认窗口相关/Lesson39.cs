using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson39_EditorUtility_编辑器默认窗口相关
{
    public class Lesson39 : EditorWindow
    {
        private float _value;
        
        [MenuItem("UnityEditorExtension/Lesson39/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow<Lesson39>();
            window.titleContent = new GUIContent("EditorUtility Introduce Window");
            window.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Show Tip Window"))
            {
                if (EditorUtility.DisplayDialog("Tip Window", "Are you sure?", "Sure", "Close"))
                {
                    Debug.Log("Sure");
                }
            }

            if (GUILayout.Button("Show Complex Tip Window"))
            {
                var id = EditorUtility.DisplayDialogComplex("Tip Complex Window", "Are you really sure?", "Sure",
                    "Close",
                    "Think");
                switch (id)
                {
                    case 0:
                        Debug.Log("Sure!");
                        break;
                    case 1:
                        Debug.Log("No!");
                        break;
                    case 2:
                        Debug.Log("I need to think...");
                        break;
                }
            }

            if (GUILayout.Button("Show Progress Bar"))
            {
                _value += 0.01f;
                EditorUtility.DisplayProgressBar("Progress Bar", "Loading...", _value);
            }
            if (GUILayout.Button("Close Progress Bar"))
            {
                _value = 0; 
                EditorUtility.ClearProgressBar();
            }
        }
    }
}