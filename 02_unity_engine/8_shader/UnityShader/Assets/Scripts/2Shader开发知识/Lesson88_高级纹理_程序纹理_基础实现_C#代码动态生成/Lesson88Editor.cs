using UnityEditor;
using UnityEngine;

namespace _2Shader开发知识.Lesson88_高级纹理_程序纹理_基础实现_C_代码动态生成
{
    [CustomEditor(typeof(Lesson88))]
    public class Lesson88Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var lesson88 = (Lesson88)target;

            if (GUILayout.Button("Update Texture"))
                lesson88.UpdateTexture();
        }
    }
}