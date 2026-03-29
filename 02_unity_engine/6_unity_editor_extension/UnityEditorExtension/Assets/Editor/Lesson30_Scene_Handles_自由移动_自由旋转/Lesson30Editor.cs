using Lesson30_Scene_Handles_自由移动_自由旋转;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson30_Scene_Handles_自由移动_自由旋转
{
    [CustomEditor(typeof(Lesson30))]
    public class Lesson30Editor : UnityEditor.Editor
    {
        private Lesson30 _lesson30;

        private void OnEnable()
        {
            _lesson30 = (Lesson30)target;
        }

        private void OnSceneGUI()
        {
            _lesson30.transform.position = Handles.FreeMoveHandle(
                _lesson30.transform.position, HandleUtility.GetHandleSize(_lesson30.transform.position), Vector3.one,
                Handles.RectangleHandleCap);

            _lesson30.transform.rotation = Handles.FreeRotateHandle(_lesson30.transform.rotation,
                Vector3.zero, HandleUtility.GetHandleSize(Vector3.zero));
        }
    }
}