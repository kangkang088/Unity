using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson40_EditorUtility_文件面板相关
{
    public class Lesson40 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson40/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow<Lesson40>();
            window.titleContent = new GUIContent("EditorUtility Introduce Window");
            window.Show();
        }

        private void OnGUI()
        {
            //得到一个任意路径，用于保存单个文件
            if (GUILayout.Button("Open File Save Panel(Any Path)"))
            {
                var path = EditorUtility.SaveFilePanel("Save file to any path", Application.dataPath, "Test", "txt");
                Debug.Log(path);
                if (!string.IsNullOrEmpty(path))
                    File.WriteAllText(path, "123");
            }

            //得到一个项目路径，用于保存单个文件
            if (GUILayout.Button("Open File Save Panel(Project Path)"))
            {
                var path = EditorUtility.SaveFilePanelInProject("Save file to project path", "Test", "txt", "tip");
                Debug.Log(path);
                if (!string.IsNullOrEmpty(path))
                    File.WriteAllText(path, "123");
            }

            //得到一个任意文件夹路径，用于保存多个文件
            if (GUILayout.Button("Get A Folder Path To Save(Any Path)"))
            {
                var directoryPath =
                    EditorUtility.SaveFolderPanel("Save files to a folder path", Application.dataPath, "Test");
                Debug.Log(directoryPath);
            }

            //得到一个任意文件路径，用于读取单个文件
            if (GUILayout.Button("Show Open File Panel"))
            {
                var path = EditorUtility.OpenFilePanel("Open File Panel", Application.dataPath, "txt");
                Debug.Log(path);
                if (!string.IsNullOrEmpty(path))
                    Debug.Log(File.ReadAllText(path));
            }

            //得到一个任意文件夹路径，用于读取多个文件
            if (GUILayout.Button("Show Open Folder Panel"))
            {
                var path = EditorUtility.OpenFolderPanel("Open Folder Panel", Application.dataPath, "txt");
                Debug.Log(path);
            }
        }
    }
}