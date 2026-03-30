using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson45_EditorApplication公共类
{
    public class Lesson45 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson45/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(Lesson45));
            window.titleContent = new GUIContent("EditorApplication Introduce Window");
            window.Show();
        }

        private void OnEnable()
        {
            EditorApplication.update += MyUpdate;
            // EditorApplication.hierarchyChanged += EditorApplicationOnHierarchyChanged;
            // EditorApplication.projectChanged += EditorApplicationOnProjectChanged;
            // EditorApplication.playModeStateChanged += EditorApplicationOnPlayModeStateChanged;
            // EditorApplication.pauseStateChanged += EditorApplicationOnPauseStateChanged;
        }

        private void EditorApplicationOnPauseStateChanged(PauseState obj)
        {
            switch (obj)
            {
                case PauseState.Paused:
                    break;
                case PauseState.Unpaused:
                    break;
            }
        }

        private void EditorApplicationOnPlayModeStateChanged(PlayModeStateChange obj)
        {
        }

        private void EditorApplicationOnProjectChanged()
        {
        }

        private void EditorApplicationOnHierarchyChanged()
        {
        }

        private void MyUpdate()
        {
            if (EditorApplication.isPlaying)
            {
                Debug.Log("Editor is playing");
                // EditorApplication.isPlaying;
                // EditorApplication.isCompiling;
                // EditorApplication.isUpdating;
            }
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Get Installation Directory"))
            {
                //Unity安装目录Data路径
                Debug.Log(EditorApplication.applicationContentsPath);
                //Unity安装目录可执行程序路径
                Debug.Log(EditorApplication.applicationPath);
            }

            if (GUILayout.Button("Exit Editor"))
            {
                EditorApplication.Exit(0);
            }

            if (GUILayout.Button("Exit Play Mode"))
            {
                EditorApplication.ExitPlaymode();
            }

            if (GUILayout.Button("Enter Play Mode"))
            {
                EditorApplication.EnterPlaymode();
            }
        }

        private void OnDestroy()
        {
            EditorApplication.update -= MyUpdate;
        }
    }
}