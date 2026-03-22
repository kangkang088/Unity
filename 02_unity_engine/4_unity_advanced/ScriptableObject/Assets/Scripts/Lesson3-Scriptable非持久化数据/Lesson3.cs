using UnityEngine;

public class Lesson3 : MonoBehaviour
{
    private void Start()
    {
        var data = ScriptableObject.CreateInstance<MyData>();
        data.id = 1;
        data.playerName = "Player1";
        data.age = 25;
    }// 释放data
}
