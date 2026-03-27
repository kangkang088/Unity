using UnityEditor;
using UnityEngine;

namespace Editor.Lesson9_EditorGUILayout_滑动条_双滑块滑动条控件
{
    public class Lesson9 : EditorWindow
    {
        [MenuItem("UnityEditorExtension/Lesson9/OpenWindow")]
        public static void ShowWindow()
        {
            var window = GetWindow<Lesson9>();
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
        private GameObject _obj;
        private int _i;
        private long _l;
        private float _f;
        private double _d;
        private string _s;
        private Vector2 _v2;
        private Vector3 _v3;
        private Vector4 _v4;
        private Rect _rect;
        private Bounds _bounds; // default float
        private BoundsInt _boundsInt;
        private int _delayedI; // not change value untile press enter or lostFocus
        private bool _isFoldOut;
        private bool _isFoldOutGroup;
        private bool _isToggleSelected;
        private bool _isLeftToggleSelected;
        private bool _isToggleGroup;
        private float _floatSlider;
        private int _intSlider;
        private float _left;
        private float _right;

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Lesson9", "Test Content", EditorStyles.boldLabel);

            _isFoldOutGroup = EditorGUILayout.BeginFoldoutHeaderGroup(_isFoldOutGroup, "Fold Group");

            if (_isFoldOutGroup)
            {
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

                _obj = (GameObject)EditorGUILayout.ObjectField("Object Field", _obj, typeof(GameObject), false);
            }

            EditorGUILayout.EndFoldoutHeaderGroup();

            _isFoldOut = EditorGUILayout.Foldout(_isFoldOut, "Fold Window", false);
            if (_isFoldOut)
            {
                _i = EditorGUILayout.IntField("Int Field", _i);
                _l = EditorGUILayout.LongField("Long Field", _l);
                _f = EditorGUILayout.FloatField("Float Field", _f);
                _d = EditorGUILayout.DoubleField("Double Field", _d);
                _s = EditorGUILayout.TextField("String Field", _s);
                _v2 = EditorGUILayout.Vector2Field("Vector2 Field", _v2);
                _v3 = EditorGUILayout.Vector3Field("Vector3 Field", _v3);
                _v4 = EditorGUILayout.Vector4Field("Vector4 Field", _v4);
                _rect = EditorGUILayout.RectField(new GUIContent("Rect Field"), _rect);
                _bounds = EditorGUILayout.BoundsField(new GUIContent("Bounds Field"), _bounds);
                _boundsInt = EditorGUILayout.BoundsIntField(new GUIContent("Bounds Int Field"), _boundsInt);
                _delayedI = EditorGUILayout.DelayedIntField("Delayed Int", _delayedI);
                EditorGUILayout.LabelField("Delayer Int Show", _delayedI.ToString());
            }

            _isToggleGroup = EditorGUILayout.BeginToggleGroup("Toggle Group", _isToggleGroup);
            _isToggleSelected = EditorGUILayout.Toggle("Toggle", _isToggleSelected);
            _isLeftToggleSelected = EditorGUILayout.ToggleLeft("Left Toggle", _isLeftToggleSelected);
            EditorGUILayout.EndToggleGroup();

            _floatSlider = EditorGUILayout.Slider("Slider", _floatSlider, 0f, 10f);
            _intSlider = EditorGUILayout.IntSlider("Int Slider", _intSlider, 0, 1000);
            EditorGUILayout.MinMaxSlider("Min Max Slider", ref _left, ref _right, 0, 10);
            EditorGUILayout.LabelField("Left",_left.ToString());
            EditorGUILayout.LabelField("Right",_right.ToString());
        }
    }
}