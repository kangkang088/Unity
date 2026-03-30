using System;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

namespace Editor.Lesson46_CompilationPipeline
{
    public class Lesson46 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson46/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(Lesson46));
            window.titleContent = new GUIContent("CompilationPipeline Introduce Window");
            window.Show();
        }
        
        private void OnEnable()
        {
            // 一个程序集编译完成后调用
            CompilationPipeline.assemblyCompilationFinished += CompilationPipelineOnAssemblyCompilationFinished;
            //所有程序集编译完成后调用
            CompilationPipeline.compilationFinished += CompilationPipelineOnCompilationFinished;
        }

        private void CompilationPipelineOnCompilationFinished(object obj)
        {
            Debug.Log("ALL Assembly Compilation Finished");
        }

        private void CompilationPipelineOnAssemblyCompilationFinished(string arg1, CompilerMessage[] arg2)
        {
            Debug.Log("编译完成的程序集名：" + arg1);
            Debug.Log(arg2.Length);
        }

        private void OnGUI()
        {
        }

        private void OnDestroy()
        {
            CompilationPipeline.assemblyCompilationFinished -= CompilationPipelineOnAssemblyCompilationFinished;
            CompilationPipeline.compilationFinished -= CompilationPipelineOnCompilationFinished;
        }
    }
}