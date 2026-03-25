using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UIManager.GetInstance().ShowPanel<MP_MainPanel>("MainPanel");
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            UIManager.GetInstance().HidePanel("MainPanel");
        }
    }
}