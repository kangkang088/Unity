using Lesson31_Scene_Handles_显示GUI;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson31_Scene_Handles_显示GUI
{
    [CustomEditor(typeof(Lesson31))]
    public class Lesson31Editor : UnityEditor.Editor
    {
        private Lesson31 _lesson31;

        private void OnEnable()
        {
            _lesson31 = target as Lesson31;
        }

        private void OnSceneGUI()
        {
            Handles.BeginGUI();

            if (GUILayout.Button("Test Button In Scene"))
                Debug.Log("Test Button In Scene");

            var w = SceneView.currentDrawingSceneView.position.width;
            var h = SceneView.currentDrawingSceneView.position.height;

            GUILayout.BeginArea(new Rect(w - 100, h - 100, 100, 100));

            GUILayout.Label("Test Label In Scene");
            if (GUILayout.Button("Test Button In Scene"))
                Debug.Log("Test Button In Scene");

            GUILayout.EndArea();

            Handles.EndGUI();
        }
    }
}