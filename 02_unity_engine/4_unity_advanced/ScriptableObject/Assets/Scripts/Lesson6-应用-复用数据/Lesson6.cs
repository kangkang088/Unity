using System;
using UnityEngine;

public class Lesson6 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Resources.Load<GameObject>("Bullet"));
        }
    }
}
