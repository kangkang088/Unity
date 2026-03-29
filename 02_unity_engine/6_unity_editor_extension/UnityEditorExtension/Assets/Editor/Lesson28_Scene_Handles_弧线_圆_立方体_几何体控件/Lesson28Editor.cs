using System;
using Lesson28_Scene_Handles_弧线_圆_立方体_几何体控件;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson28_Scene_Handles_弧线_圆_立方体_几何体控件
{
    [CustomEditor(typeof(Lesson28))]
    public class Lesson28Editor : UnityEditor.Editor
    {
        private Lesson28 _lesosn28;

        private void OnEnable()
        {
            _lesosn28 = target as Lesson28;
        }

        private void OnSceneGUI()
        {
            Handles.color = Color.red;
            Handles.DrawWireArc(_lesosn28.transform.position,
                _lesosn28.transform.up,
                _lesosn28.transform.right, 30,
                5);

            Handles.color = Color.magenta;
            var angle = new Quaternion(0, Mathf.Sin(15f / 2 * Mathf.Deg2Rad), 0, Mathf.Cos(15f / 2 * Mathf.Deg2Rad));
            Handles.DrawSolidArc(_lesosn28.transform.position, -_lesosn28.transform.up,
                angle * _lesosn28.transform.right, 30,
                5);

            Handles.color = Color.yellow;
            Handles.DrawWireDisc(_lesosn28.transform.position, _lesosn28.transform.up, 4);

            Handles.color = Color.blue;
            Handles.DrawSolidDisc(_lesosn28.transform.position, -_lesosn28.transform.up, 3);

            Handles.color = Color.white;
            Handles.DrawWireCube(_lesosn28.transform.position, Vector3.one);

            Handles.color = Color.cyan;
            Handles.DrawAAConvexPolygon(Vector3.zero, Vector3.right, Vector3.right + Vector3.up,
                Vector3.up); //antialiasing
        }
    }
}