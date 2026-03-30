using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson44_PrefabUtility公共类
{
    public class Lesson44 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson44/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(Lesson44));
            window.titleContent = new GUIContent("PrefabUtility Introduce Window");
            window.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Create Prefab Dynamically"))
            {
                var obj = new GameObject
                {
                    name = "Prefab Dynamically"
                };
                obj.AddComponent<BoxCollider>();

                PrefabUtility.SaveAsPrefabAsset(obj, "Assets/Resources/Test.prefab");

                DestroyImmediate(obj);
            }

            //不能实例化(已经实例化，但不在传统的Scene窗口显示，这里是一个已经实例化出来的对象，想象一下运行中实例化对象的样子，所以可以给预设体加子对象）
            if (GUILayout.Button("Load Prefab Dynamically"))
            {
                var obj = PrefabUtility.LoadPrefabContents("Assets/Resources/Test.prefab");
                if (!obj.GetComponent<MeshRenderer>())
                    obj.AddComponent<MeshRenderer>();
                PrefabUtility.SaveAsPrefabAsset(obj, "Assets/Resources/Test.prefab");
                PrefabUtility.UnloadPrefabContents(obj);
            }

            //直接修改预设体，加载出来的是一个预设体，不能给预设体加子对象啥的
            if (GUILayout.Button("Change Prefab Dynamically"))
            {
                var asset = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Test.prefab");
                if (!asset.GetComponent<SphereCollider>())
                    asset.AddComponent<SphereCollider>();
                PrefabUtility.SavePrefabAsset(asset, out var success);
                if (success)
                    Debug.Log("Success!");
            }

            if (GUILayout.Button("Instantiate Prefab Dynamically"))
            {
                var obj = PrefabUtility.InstantiatePrefab(
                    AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Test.prefab"));
            }
        }
    }
}