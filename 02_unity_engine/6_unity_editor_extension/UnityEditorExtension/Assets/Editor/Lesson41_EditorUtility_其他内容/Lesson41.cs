using UnityEditor;
using UnityEngine;

namespace Editor.Lesson41_EditorUtility_其他内容
{
    public class Lesson41 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson41/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow<Lesson41>();
            window.titleContent = new GUIContent("EditorUtility Introduce Window");
            window.Show();
        }

        public GameObject obj1;

        private void OnGUI()
        {
            // EditorUtility.CompressTexture(texture,format,quality);

            obj1 = (GameObject)EditorGUILayout.ObjectField("Target object", obj1, typeof(GameObject), true);
            if (GUILayout.Button("Search dependent resources"))
            {
                var dependencies = EditorUtility.CollectDependencies(new Object[] { obj1 });
                Selection.objects = dependencies;
            }
        }
    }
}