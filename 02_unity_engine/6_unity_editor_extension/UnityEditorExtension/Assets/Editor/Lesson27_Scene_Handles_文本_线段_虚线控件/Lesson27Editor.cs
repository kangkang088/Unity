using Lesson27_Scene_Handles_文本_线段_虚线控件;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson27_Scene_Handles_文本_线段_虚线控件
{
    [CustomEditor(typeof(Lesosn27))]
    public class Lesson27Editor : UnityEditor.Editor
    {
        private Lesosn27 _lesosn27;

        private void OnEnable()
        {
            _lesosn27 = target as Lesosn27;
        }

        private void OnSceneGUI()
        {
            Handles.color = Color.red;
            Handles.Label(_lesosn27.transform.position + new Vector3(-1, 0, 0), _lesosn27.name); //un effect color
            Handles.DrawLine(_lesosn27.transform.position, _lesosn27.transform.position + new Vector3(10, 0, 0), 5);
            Handles.DrawDottedLine(_lesosn27.transform.position, _lesosn27.transform.position + new Vector3(-10, 0, 0),
                5);
        }
    }
}