using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson43_AssetDatabase_常用API
{
    public class Lesson43 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson43/OpenWindow")]
        private static void OpenWindow()
        {
            var window = GetWindow<Lesson43>();
            window.titleContent = new GUIContent("AssetDatabase Introduce Window");
            window.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Create assets"))
            {
                var mat = new Material(Shader.Find($"Specular"));
                AssetDatabase.CreateAsset(mat, "Assets/Resources/Lesson43Mat.mat");
            }

            if (GUILayout.Button("Create folder"))
            {
                AssetDatabase.CreateFolder("Assets/Resources", "Lesson43Test");
            }

            if (GUILayout.Button("Copy assets"))
            {
                AssetDatabase.CopyAsset("Assets/Editor Default Resources/sample.png",
                    "Assets/Resources/Lesson43Test/sample.png");
            }

            if (GUILayout.Button("Move assets"))
            {
                AssetDatabase.MoveAsset("Assets/Resources/Lesson43Test/sample.png",
                    "Assets/Resources/sample.png");
            }

            if (GUILayout.Button("Delete assets"))
            {
                AssetDatabase.DeleteAsset("Assets/Resources/sample.png");
            }

            if (GUILayout.Button("Delete multi assets"))
            {
                var failedList = new List<string>();
                AssetDatabase.DeleteAssets(new[] { "Assets/Resources/sample.png", "Assets/Resources/sample22.png" },
                    failedList);

                foreach (var failedPath in failedList)
                {
                    Debug.Log(failedPath);
                }
            }

            if (GUILayout.Button("Get selected assets path"))
            {
                var path = AssetDatabase.GetAssetPath(Selection.activeObject);
                Debug.Log(path);
            }

            if (GUILayout.Button("Load assets"))
            {
                var texture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Resources/sample.png");
                Debug.Log(texture.name);
            }

            if (GUILayout.Button("Load  multi assets"))
            {
                //一般用来加载图集，返回一个数组，第一个是图集本身，其他依次为图集图片

                // var atlas = AssetDatabase.LoadAllAssetsAtPath(path);
            }

            if (GUILayout.Button("Refresh Editor"))
            {
                AssetDatabase.Refresh();
            }

            if (GUILayout.Button("Get ab name which the asset belongs to"))
            {
                // AssetDatabase.GetImplicitAssetBundleName(path);
            }
        }
    }
}