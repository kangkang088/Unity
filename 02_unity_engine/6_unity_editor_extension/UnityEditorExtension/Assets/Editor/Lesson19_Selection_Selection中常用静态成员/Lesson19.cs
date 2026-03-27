using System.Text;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson19_Selection_Selection中常用静态成员
{
    public class Lesson19 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson19/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(Lesson19));
            window.titleContent = new GUIContent("EditorGUIUtility Introduce Window");
            window.Show();
        }

        private StringBuilder _currentSelectedObjectName = new("Null");

        private void OnGUI()
        {
            if (GUILayout.Button("Get Current Selected GameObject"))
            {
                if (Selection.activeObject)
                {
                    _currentSelectedObjectName.Clear();
                    _currentSelectedObjectName.Append(Selection.activeObject.name);

                    Debug.Log(Selection.activeObject is GameObject ? "It is a GameObject" : "It is not a GameObject");
                }
                else
                {
                    _currentSelectedObjectName.Clear();
                    _currentSelectedObjectName.Append("Null");
                }
            }

            EditorGUILayout.LabelField("Selected GameObject", _currentSelectedObjectName.ToString());

            var obj = Selection.activeObject; // current selected object.When multi selected,only the first.            
            var gameObject = Selection.activeGameObject; // gameObject...
            var transform = Selection.activeTransform; // transform...
            var allObjects = Selection.objects; //objects,all
            var allGameObjects = Selection.gameObjects; // gameObjects,all
            var allTransforms = Selection.transforms; //transforms,all
        }
    }
}