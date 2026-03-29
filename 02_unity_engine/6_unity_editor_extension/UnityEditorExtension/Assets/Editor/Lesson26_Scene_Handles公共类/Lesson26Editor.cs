using Lesson26_Scene_Handles公共类;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson26_Scene_Handles公共类
{
    [CustomEditor(typeof(Lesson26))]
    public class Lesson26Editor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            Debug.Log("自定义脚本响应Scene");
        }
    }
}