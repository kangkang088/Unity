using UnityEditor;
using UnityEngine;

namespace Editor.Lesson1_自定义菜单栏拓展
{
    public class Lesson1 : MonoBehaviour
    {
        [MenuItem("UnityEditorExtension/Lesson1/Test _F4")]
        public static void TestFunction()
        {
            Debug.Log("TestFunction");
        }
        
        [MenuItem("GameObject/UnityEditorExtension/Lesson1/TestHierarchy")]
        public static void TestHierarchalFunction()
        {
            Debug.Log("TestHierarchalFunction");
        }
        
        [MenuItem("Assets/UnityEditorExtension/Lesson1/TestAssets")]
        public static void TestAssetsFunction()
        {
            Debug.Log("TestAssetsFunction");
        }
        
        [MenuItem("CONTEXT/Lesson1Test/UnityEditorExtension/Lesson1/TestComponent")]
        public static void TestComponentFunction()
        {
            Debug.Log("TestComponentFunction");
        }
    }
}
