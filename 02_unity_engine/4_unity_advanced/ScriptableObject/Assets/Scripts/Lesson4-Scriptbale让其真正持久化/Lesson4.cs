using System.IO;
using UnityEngine;

public class Lesson4 : MonoBehaviour
{
    public MyData data;
    
    private void Start()
    {
        // MyData data = Resources.Load<MyData>("MyData");
        // data.id = 2;
        // data.playerName = "Player1";
        // data.age = 500;
        //
        // var jsonStr = JsonUtility.ToJson(data);
        //
        // File.WriteAllText(Application.streamingAssetsPath + "/MyData.json", jsonStr);

        var jsonStr = File.ReadAllText(Application.streamingAssetsPath + "/MyData.json");
        JsonUtility.FromJsonOverwrite(jsonStr, data);
    }
}