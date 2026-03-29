using Lesson29_Scene_Handles_移动轴_旋转轴_缩放轴;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson29_Scene_Handles_移动轴_旋转轴_缩放轴
{
    [CustomEditor(typeof(Lesson29))]
    public class Lesson29Editor : UnityEditor.Editor
    {
        private Lesson29 _lesson29;

        private void OnEnable()
        {
            _lesson29 = target as Lesson29;
        }

        private void OnSceneGUI()
        {
            // two are new and old,they are same
            _lesson29.transform.position =
                Handles.DoPositionHandle(_lesson29.transform.position, _lesson29.transform.rotation);
            // _lesson29.transform.position =
            //     Handles.PositionHandle(_lesson29.transform.position, _lesson29.transform.rotation);

            _lesson29.transform.rotation = Handles.DoRotationHandle(
                _lesson29.transform.rotation, _lesson29.transform.position);
            // _lesson29.transform.rotation = Handles.RotationHandle(
            //     _lesson29.transform.rotation, _lesson29.transform.position);

            _lesson29.transform.localScale = Handles.DoScaleHandle(
                _lesson29.transform.localScale, _lesson29.transform.position, _lesson29.transform.rotation,
                HandleUtility.GetHandleSize(Vector3.zero));
            // _lesson29.transform.localScale = Handles.ScaleHandle(_lesson29.transform.localScale,
            //     _lesson29.transform.position, _lesson29.transform.rotation, HandleUtility.GetHandleSize(Vector3.zero));
        }
    }
}