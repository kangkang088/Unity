using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Assembly = System.Reflection.Assembly;

namespace Editor.UIPanelTool
{
    public class UIPanelTool : EditorWindow
    {
        private readonly List<string> _filterNames = new()
        {
            "Image", "Text (TMP)", "RawImage", "Background", "Checkmark", "Label", "Text (Legacy)", "Arrow",
            "Placeholder", "Fill", "Handle", "Viewport", "Scrollbar Vertical", "Scrollbar Horizontal"
        };

        private Dictionary<string, Type> _controlType = new();

        private string _panelBaseScript;
        private string _panelScript;

        private string _panelName;

        private Vector2 _scrollPos1;
        private Vector2 _scrollPos2;

        [MenuItem("GameObject/UI/自动生成")]
        public static void ShowWindow()
        {
            var window = GetWindow<UIPanelTool>();
            window.titleContent = new GUIContent("自动生成");
            window.Show();
            window.InitInfo();
        }

        private void InitInfo()
        {
            _panelBaseScript = "";
            _panelScript = "";

            _controlType.Clear();

            _scrollPos1 = Vector2.zero;
            _scrollPos2 = Vector2.zero;

            var obj = Selection.activeGameObject;
            if (!obj) return;

            _panelName = obj.name;

            var controlStrInfo = new ControlStrInfo();

            var btnControlInfo = FindControl<Button>(obj);
            if (btnControlInfo == null) return;
            controlStrInfo += btnControlInfo;
            btnControlInfo = FindControl<Toggle>(obj);
            if (btnControlInfo == null) return;
            controlStrInfo += btnControlInfo;
            btnControlInfo = FindControl<Slider>(obj);
            if (btnControlInfo == null) return;
            controlStrInfo += btnControlInfo;
            btnControlInfo = FindControl<InputField>(obj);
            if (btnControlInfo == null) return;
            controlStrInfo += btnControlInfo;
            btnControlInfo = FindControl<Dropdown>(obj);
            if (btnControlInfo == null) return;
            controlStrInfo += btnControlInfo;
            btnControlInfo = FindControl<ScrollRect>(obj);
            if (btnControlInfo == null) return;
            controlStrInfo += btnControlInfo;
            btnControlInfo = FindControl<Text>(obj);
            if (btnControlInfo == null) return;
            controlStrInfo += btnControlInfo;
            btnControlInfo = FindControl<Image>(obj);
            if (btnControlInfo == null) return;
            controlStrInfo += btnControlInfo;
            btnControlInfo = FindControl<RawImage>(obj);
            if (btnControlInfo == null) return;
            controlStrInfo += btnControlInfo;
            btnControlInfo = FindControl<TextMeshProUGUI>(obj);
            if (btnControlInfo == null) return;
            controlStrInfo += btnControlInfo;

            var baseStr = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Editor/UIPanelTool/UIConfigBase.txt");
            _panelBaseScript = string.Format(baseStr.text, obj.name, controlStrInfo.nameStr, controlStrInfo.findStr,
                controlStrInfo.listenerStr, controlStrInfo.funcStr);

            var str = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Editor/UIPanelTool/UIConfig.txt");
            _panelScript = string.Format(str.text, obj.name, obj.name);
        }

        private ControlStrInfo FindControl<T>(GameObject obj) where T : UIBehaviour
        {
            var info = new ControlStrInfo();

            var controls = obj.GetComponentsInChildren<T>();

            for (var i = 0; i < controls.Length; i++)
            {
                if (_filterNames.Contains(controls[i].gameObject.name) ||
                    controls[i].gameObject.name == obj.gameObject.name) continue;

                if (_controlType.ContainsKey(controls[i].gameObject.name))
                {
                    if (_controlType[controls[i].gameObject.name] == typeof(T))
                    {
                        EditorUtility.DisplayDialog("重复控件名", $"有两个类型一致的控件同名: {controls[i].gameObject.name}", "确定");
                        return null;
                    }

                    continue;
                }

                _controlType.Add(controls[i].gameObject.name, typeof(T));

                info.nameStr += $"public {typeof(T).Name} {controls[i].gameObject.name};\n\t";
                info.findStr +=
                    $"{controls[i].gameObject.name} = transform.Find(\"{GetPath(controls[i].transform, obj.transform)}\").GetComponent<{typeof(T).Name}>();\n\t\t";

                switch (typeof(T).Name)
                {
                    case "Button":
                        info.listenerStr +=
                            $"{controls[i].gameObject.name}.onClick.AddListener(On{controls[i].gameObject.name}Click);\n\t\t";
                        info.funcStr += $"protected virtual void On{controls[i].gameObject.name}Click(){{}}\n\t";
                        break;
                    case "Toggle":
                        info.listenerStr +=
                            $"{controls[i].gameObject.name}.onValueChanged.AddListener(On{controls[i].gameObject.name}ValueChanged);\n\t\t";
                        info.funcStr +=
                            $"protected virtual void On{controls[i].gameObject.name}ValueChanged(bool value){{}}\n\t";
                        break;
                    case "Slider":
                        info.listenerStr +=
                            $"{controls[i].gameObject.name}.onValueChanged.AddListener(On{controls[i].gameObject.name}ValueChanged);\n\t\t";
                        info.funcStr +=
                            $"protected virtual void On{controls[i].gameObject.name}ValueChanged(float value){{}}\n\t";
                        break;
                }
            }

            return info;
        }

        private string GetPath(Transform obj, Transform panelTrans)
        {
            var path = obj.name;

            while (obj.transform.parent != panelTrans)
            {
                path = obj.parent.name + "/" + path;
                obj = obj.parent;
            }

            return path;
        }

        private void OnGUI()
        {
            if (string.IsNullOrEmpty(_panelBaseScript))
            {
                GUILayout.Label("存在同名同类型控件，请先解决");
                return;
            }

            _scrollPos1 = EditorGUILayout.BeginScrollView(_scrollPos1);

            GUILayout.Label(_panelBaseScript);

            EditorGUILayout.EndScrollView();

            GUILayout.Label("----------------------------------------------");

            _scrollPos2 = EditorGUILayout.BeginScrollView(_scrollPos2);

            GUILayout.Label(_panelScript);

            EditorGUILayout.EndScrollView();

            if (GUILayout.Button("自动生成脚本"))
            {
                var path = EditorUtility.SaveFilePanel("保存自动生成的脚本", Application.dataPath + "/Scripts/",
                    _panelName + "Base", "cs");
                if (!string.IsNullOrEmpty(path))
                {
                    File.WriteAllText(path, _panelBaseScript);
                    // path = path.Replace("Base", "");
                    var index = path.LastIndexOf("Base", StringComparison.Ordinal);
                    path = path[..index] + ".cs";
                    if (!File.Exists(path))
                        File.WriteAllText(path, _panelScript);

                    CompilationPipeline.assemblyCompilationFinished += CompilationPipelineOnAssemblyCompilationFinished;

                    AssetDatabase.Refresh();
                }
            }
        }

        private void CompilationPipelineOnAssemblyCompilationFinished(string arg1, CompilerMessage[] arg2)
        {
            if (arg1.Contains("Assembly-CSharp.dll"))
            {
                var assembly =
                    Assembly.LoadFrom(Application.dataPath.Substring(0,
                                          Application.dataPath.LastIndexOf("Assets", StringComparison.Ordinal)) +
                                      arg1);
                Selection.activeGameObject.AddComponent(assembly.GetType(_panelName));
                Debug.Log(_panelName);
                CompilationPipeline.assemblyCompilationFinished -= CompilationPipelineOnAssemblyCompilationFinished;
            }
        }
    }
}