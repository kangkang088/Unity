using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public MyData myData;

    public Button btn2;
    
    private void Start()
    {
        Debug.Log(myData.age);
        
        btn2.onClick.AddListener(() =>
        {
            Debug.Log(myData.age);
        });
    }
}
