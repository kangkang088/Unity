using Lesson32_Scene_HandleUtility公共类;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson32_Scene_HandleUtility公共类
{
    [CustomEditor(typeof(Lesson32))]
    public class Lesson32Editor : UnityEditor.Editor
    {
        private Lesson32 _lesson32;

        private void OnEnable()
        {
            _lesson32 = target as Lesson32;
        }

        private void OnSceneGUI()
        {
            var relativeSize = HandleUtility.GetHandleSize(Vector3.zero);

            var guiPos = HandleUtility.WorldToGUIPoint(_lesson32.transform.position);
            Handles.BeginGUI();

            GUI.Button(new Rect(guiPos.x, guiPos.y, 100, 50), "Test Button");

            Handles.EndGUI();

            var ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

            if (Physics.Raycast(ray, out var hit))
                Debug.Log(hit.collider.name);

            var distanceFromLineToCursor = HandleUtility.DistanceToLine(Vector3.zero, Vector3.up * 5);
            // Debug.Log(distanceFromLineToCursor);

            // var obj = HandleUtility.PickGameObject(Event.current.mousePosition, true);
            // if (obj != null)
            //     Debug.Log("Selected:" + obj.name);
        }
    }
}