using UnityEditor;
using UnityEngine;

namespace Editor.Lesson3_EditorGUI是什么
{
    public class Lesson3 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson3/OpenWindow")]
        private static void OpenWindow()
        {
            var window = GetWindow<Lesson3>();
            window.titleContent = new GUIContent("EditorGUI Introduce Window");
            window.Show();
        }
        
        private void Start()
        {
            // GUILayout.Button("Sure", GUILayout.Height(30), GUILayout.Width(100));      
        }

        private void OnGUI()
        {
            
        }
    }
}
