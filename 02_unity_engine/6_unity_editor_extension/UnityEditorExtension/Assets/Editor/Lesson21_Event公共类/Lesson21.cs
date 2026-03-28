using System;
using UnityEditor;
using UnityEngine;

namespace Editor.Lesson21_Event公共类
{
    public class Lesson21 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson21/OpenWindow")]
        private static void OpenWindow()
        {
            var window = GetWindow(typeof(Lesson21));
            window.titleContent = new GUIContent("Event Introduce Window");
            window.Show();
        }

        private void OnGUI()
        {
            var e = Event.current;
            if (e.alt)
            {
                Debug.Log("Alt pressed");
            }

            var sPressed = e.shift; //is shift pressed?
            var cPressed = e.control; //is control pressed?
            var mPressed = e.isMouse; //is mouse pressed?
            var whichMPressed = e.button; //mouse 0-left 1-right 2-middle
            var mPos = e.mousePosition; //mouse position
            var kPressed = e.isKey; //is keyboard pressed?
            var whichKeyCharPressed = e.character; //which key char pressed in keyboard
            var whichKeyCodePressed = e.keyCode; //which keycode pressed in keyboard

            //event type
            switch (e.type)
            {
                case EventType.MouseDown:
                    break;
                case EventType.MouseUp:
                    break;
                case EventType.MouseMove:
                    break;
                case EventType.MouseDrag:
                    break;
                case EventType.KeyDown:
                    break;
                case EventType.KeyUp:
                    break;
                case EventType.ScrollWheel:
                    break;
                case EventType.Repaint:
                    break;
                case EventType.Layout:
                    break;
                case EventType.DragUpdated:
                    break;
                case EventType.DragPerform:
                    break;
                case EventType.DragExited:
                    break;
                case EventType.Ignore:
                    break;
                case EventType.Used:
                    break;
                case EventType.ValidateCommand:
                    break;
                case EventType.ExecuteCommand:
                    break;
                case EventType.ContextClick:
                    break;
                case EventType.MouseEnterWindow:
                    break;
                case EventType.MouseLeaveWindow:
                    break;
                case EventType.TouchDown:
                    break;
                case EventType.TouchUp:
                    break;
                case EventType.TouchMove:
                    break;
                case EventType.TouchEnter:
                    break;
                case EventType.TouchLeave:
                    break;
                case EventType.TouchStationary:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Debug.Log(e.capsLock ? "开启大写" : "大写关闭");
            if (e.command)
                Debug.Log("PC WIN/MAC COMMAND pressed");

            switch (e.commandName)
            {
                case "Copy":
                    Debug.Log("Ctrl+c pressed");
                    break;
                case "Paste":
                    Debug.Log("Ctrl+v pressed");
                    break;
                case "Cut":
                    Debug.Log("Ctrl+x pressed");
                    break;
            }

            //鼠标前后两帧移动距离
            var delta = e.delta;

            //是否是功能键输入
            var isFunctionKey = e.functionKey;

            //小键盘是否开启
            var isNumeric = e.numeric;

            //避免组合键冲突-在处理完对应输入事件后，可以手动调用一次，阻止事件继续派发，和其他编辑器窗口事件逻辑冲突。
            e.Use();
        }
    }
}