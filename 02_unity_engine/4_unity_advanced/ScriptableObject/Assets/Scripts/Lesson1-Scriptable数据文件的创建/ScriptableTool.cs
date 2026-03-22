using UnityEditor;
using UnityEngine;

public class ScriptableTool : MonoBehaviour
{
#if UNITY_EDITOR

    [MenuItem("Tools/Create MyData")]
    public static void CreateMyData()
    {
        var myData = ScriptableObject.CreateInstance<MyData>();
        myData.id = 1;
        myData.playerName = "Player1";
        myData.age = 25;

        const string assetPath = "Assets/Resources/MyDataByTool.asset";
        AssetDatabase.CreateAsset(myData, assetPath);
        AssetDatabase.SaveAssets();
        Debug.Log("MyData asset created at: " + assetPath);
        AssetDatabase.Refresh();
    }

#endif
}