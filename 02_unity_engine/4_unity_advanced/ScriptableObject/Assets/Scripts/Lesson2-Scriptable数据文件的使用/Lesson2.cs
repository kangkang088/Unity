using UnityEngine;
using UnityEngine.UI;

public class Lesson2 : MonoBehaviour
{
    public MyData myData;

    public Button btn1;
    
    private void Start()
    {
        Debug.Log(myData.age);
        
        btn1.onClick.AddListener(() =>
        {
            myData.age = 20;
            Debug.Log(myData.age);
        });
    }
}
