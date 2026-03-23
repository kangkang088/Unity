using UnityEngine;
using UnityEngine.EventSystems;

public class Lesson13 : MonoBehaviour,IMoveHandler
{
    private void Start()
    {
        
    }

    public void OnMove(AxisEventData eventData)
    {
        Debug.Log("Move");
    }
}
