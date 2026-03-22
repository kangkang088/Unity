using UnityEngine;

public class Lesson5 : MonoBehaviour
{
    public RoleInfo roleInfo;
    
    private void Start()
    {
        for (int i = 0; i < roleInfo.roleLists.Count; i++)
        {
            roleInfo.roleLists[i].ShowInfo();
        }
    }
}
