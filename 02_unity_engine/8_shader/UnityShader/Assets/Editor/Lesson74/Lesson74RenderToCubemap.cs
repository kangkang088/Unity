using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson74
{
    public class Lesson74RenderToCubemap : EditorWindow
    {
        private GameObject _obj;
        private Cubemap _cubemap;

        [MenuItem("Cubemap Generate dynamically/Open Window")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(Lesson74RenderToCubemap));
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("选择需要生成Cubemap的对象");
            _obj = (GameObject)EditorGUILayout.ObjectField(_obj, typeof(GameObject), true);
            GUILayout.Label("动态生成的立方体纹理");
            _cubemap = (Cubemap)EditorGUILayout.ObjectField(_cubemap, typeof(Cubemap), false);

            if (GUILayout.Button("生成立方体纹理"))
            {
                if (!_obj || !_cubemap)
                {
                    EditorUtility.DisplayDialog("Tip", "请先关联对象和立方体纹理", "确认");
                    return;
                }

                var tempObj = new GameObject("TempObj")
                {
                    transform =
                    {
                        position = _obj.transform.position
                    }
                };

                var camera = tempObj.AddComponent<Camera>();
                camera.RenderToCubemap(_cubemap);
                DestroyImmediate(tempObj);
            }
        }
    }
}