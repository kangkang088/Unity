using UnityEditor;
using UnityEngine;

namespace Editor.Lesson5_EditorGUILayout_枚举选择_整数选择_按下触发按钮
{
    public class Lesson5 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson5/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow<Lesson5>();
            window.titleContent = new GUIContent("EditorGUILayout Introduce Window");
            window.Show();
        }

        private enum ETestType
        {
            One = 1,
            Two = 2,
            Three = 3
        }

        private int _layer;
        private string _tag;
        private Color _color;
        private ETestType _testTypeSingle;
        private ETestType _testTypeMulti;
        private string[] _strs = { "choice1", "choice2", "choice3", "choice4" };
        private int[] _ints = { 1, 2, 3, 4 };
        private int _int;

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Lesson5", "Test Content", EditorStyles.boldLabel);

            _layer = EditorGUILayout.LayerField("Layer Choice", _layer);

            _tag = EditorGUILayout.TagField("Tag Choice", _tag);

            _color = EditorGUILayout.ColorField(new GUIContent("Color Choice"), _color, true, true, true);

            _testTypeSingle = (ETestType)EditorGUILayout.EnumPopup("Enum Choice", _testTypeSingle); // single choice

            _testTypeMulti =
                (ETestType)EditorGUILayout.EnumFlagsField("Enum Flags", _testTypeMulti); // multi choice

            _int = EditorGUILayout.IntPopup("Integer Choice", _int, _strs, _ints);
            EditorGUILayout.LabelField("int", _int.ToString());

            if (EditorGUILayout.DropdownButton(new GUIContent("Dropdown Button"), FocusType.Keyboard))
            {
                Debug.Log("按下就触发，不用抬起！");
            }
        }
    }
}