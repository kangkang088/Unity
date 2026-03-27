using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Editor.Lesson20_Selection_Selection中常用静态方法
{
    public class Lesson20 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson20/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(Lesson20));
            window.titleContent = new GUIContent("EditorGUIUtility Introduce Window");
            window.Show();
        }

        private Object _targetObj;

        private void Awake()
        {
            Selection.selectionChanged += SelectionChanged;
        }

        private void SelectionChanged()
        {
            Debug.Log("SelectionChanged");
        }

        private void OnGUI()
        {
            _targetObj = EditorGUILayout.ObjectField("Target object", _targetObj, typeof(GameObject), true);
            if (GUILayout.Button("Judge target obj has been selected"))
                Debug.Log(
                    Selection.Contains(_targetObj) ? "Target object is selected" : "Target object is not selected");

            if (GUILayout.Button("Filter all objects"))
            {
                var objs = Selection.GetFiltered<Object>(SelectionMode.Assets | SelectionMode.DeepAssets);
                foreach (var obj in objs)
                {
                    Debug.Log(obj.name);
                }
            }
        }

        private void OnDestroy()
        {
            Selection.selectionChanged -= SelectionChanged;
        }
    }
}