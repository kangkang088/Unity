using Lesson23_Inspector_数组_List属性自定义显示;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson23_Inspector_数组_List属性自定义显示
{
    [CustomEditor(typeof(Lesson23))]
    public class Lesson23Editor : UnityEditor.Editor
    {
        //default draw
        private SerializedProperty _strs;
        private SerializedProperty _ints;
        private SerializedProperty _objs;
        private SerializedProperty _objsList;

        //custom draw
        private SerializedProperty _customObjsList;

        private int _count;

        private void OnEnable()
        {
            _strs = serializedObject.FindProperty("strs");
            _ints = serializedObject.FindProperty("ints");
            _objs = serializedObject.FindProperty("objs");
            _objsList = serializedObject.FindProperty("objsList");
            _customObjsList = serializedObject.FindProperty("customObjsList");

            _count = _customObjsList.arraySize;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            //default draw
            EditorGUILayout.PropertyField(_strs, new GUIContent("String Array"));
            EditorGUILayout.PropertyField(_ints, new GUIContent("Int Array"));
            EditorGUILayout.PropertyField(_objs, new GUIContent("Obj Array"));
            EditorGUILayout.PropertyField(_objsList, new GUIContent("Obj List"));

            //custom draw
            _count = EditorGUILayout.IntField("List Count", _count);

            if (_count < _customObjsList.arraySize)
            {
                for (var i = _customObjsList.arraySize - 1; i >= _count; i--)
                {
                    _customObjsList.DeleteArrayElementAtIndex(i);
                }
            }

            for (var i = 0; i < _count; i++)
            {
                if (_customObjsList.arraySize <= i)
                    _customObjsList.InsertArrayElementAtIndex(i);

                var indexProperty = _customObjsList.GetArrayElementAtIndex(i);
                EditorGUILayout.ObjectField(indexProperty, new GUIContent("index " + i));
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}