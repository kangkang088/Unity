using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVCTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MainPresenter.ShowMe();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            MainPresenter.HideMe();
        }
    }
}