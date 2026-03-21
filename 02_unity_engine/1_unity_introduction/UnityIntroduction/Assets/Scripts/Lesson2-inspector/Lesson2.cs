using UnityEngine;

public class Lesson2 : MonoBehaviour
{
    [ContextMenuItem("测试","Test")]
    public int i;

    [Range(5,10)]
    public float value;
    
    private void Start()
    {
        
    }

    private void Test()
    {
        Debug.Log(value);
    }

    [ContextMenu("hahahahaha")]
    private void TestFun()
    {
        Debug.Log("cecececeec");
    }
}
