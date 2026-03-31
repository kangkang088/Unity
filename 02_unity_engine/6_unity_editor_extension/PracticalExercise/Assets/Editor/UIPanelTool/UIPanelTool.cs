using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Editor.UIPanelTool
{
    public class UIPanelTool : EditorWindow
    {
        private readonly List<string> _filterNames = new()
        {
            "Image", "Text (TMP)", "RawImage", "Background", "Checkmark", "Label", "Text (Legacy)", "Arrow",
            "Placeholder", "Fill", "Handle", "Viewport"
        };

        private Dictionary<string, Type> _controlType = new();

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
            var obj = Selection.activeGameObject;
            if (!obj) return;

            var btnInfo = FindControl<Button>(obj);
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
                    $"{controls[i].gameObject.name} = transform.Find(\"{controls[i].gameObject.name}\").GetComponent<{typeof(T).Name}>();\n\t\t";

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

        private void OnGUI()
        {
            if (GUILayout.Button("自动生成脚本"))
            {
                var path = EditorUtility.SaveFilePanel("保存自动生成的脚本", Application.dataPath, "", "cs");
                if (!string.IsNullOrEmpty(path))
                {
                }
            }
        }
    }
}