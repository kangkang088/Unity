using Lesson22_Inspector_Inspector窗口拓展;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson22_Inspector_Inspector窗口拓展
{
    [CustomEditor(typeof(Lesson22))]
    public class Lesson22Editor : UnityEditor.Editor
    {
        private SerializedProperty _atk;
        private SerializedProperty _def;
        private SerializedProperty _obj;

        private bool _foldOut;

        private void OnEnable()
        {
            //serializedObject = Lesson22 in CustomEditor
            _atk = serializedObject.FindProperty("atk");
            _def = serializedObject.FindProperty("def");
            _obj = serializedObject.FindProperty("obj");
        }

        public override void OnInspectorGUI()
        {
            // base.OnInspectorGUI();
            serializedObject.Update();

            _foldOut = EditorGUILayout.BeginFoldoutHeaderGroup(_foldOut, "Base Properties");

            if (_foldOut)
            {
                if (GUILayout.Button("Get Custom Inspector Component Object"))
                {
                    //target指的是自定义拓展的脚本对象，target.name指的是自定义拓展脚本所挂载的对象的名字
                    Debug.Log("target : " + target.GetType().Name);
                    Debug.Log("target.name : " +target.name);
                }

                EditorGUILayout.IntSlider(_atk, 0, 10, "ATK");
                _atk.intValue = EditorGUILayout.IntField("ATK Value", _atk.intValue);
                _def.intValue = EditorGUILayout.IntField("Def", _def.intValue);

                EditorGUILayout.ObjectField(_obj, new GUIContent("Object"));
            }

            EditorGUILayout.EndFoldoutHeaderGroup();

            serializedObject.ApplyModifiedProperties();
        }
    }
}