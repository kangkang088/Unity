using Lesson25_Inspector_字典属性自定义显示;
using UnityEditor;

namespace Editor.Lesson25_Inspector_字典属性自定义显示
{
    [CustomEditor(typeof(Lesson25))]
    public class Lesson25Editor : UnityEditor.Editor
    {
        private SerializedProperty _keys;
        private SerializedProperty _values;
        private int _dicCount;

        private void OnEnable()
        {
            _keys = serializedObject.FindProperty("keys");
            _values = serializedObject.FindProperty("values");
            _dicCount = _keys.arraySize;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            _dicCount = EditorGUILayout.IntField("Dic Count", _dicCount);

            for (var i = _keys.arraySize - 1; i >= _dicCount; i--)
            {
                _keys.DeleteArrayElementAtIndex(i);
                _values.DeleteArrayElementAtIndex(i);
            }

            for (var i = 0; i < _dicCount; i++)
            {
                if (_keys.arraySize <= i)
                {
                    _keys.InsertArrayElementAtIndex(i);
                    _values.InsertArrayElementAtIndex(i);
                }

                var key = _keys.GetArrayElementAtIndex(i);
                var value = _values.GetArrayElementAtIndex(i);

                EditorGUILayout.BeginHorizontal();

                key.intValue = EditorGUILayout.IntField("Key", key.intValue);
                value.stringValue = EditorGUILayout.TextField("Value", value.stringValue);

                EditorGUILayout.EndHorizontal();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}