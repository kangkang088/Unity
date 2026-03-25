using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainController : MonoBehaviour
{
    private MainView mainView;

    private static MainController controller;

    public static MainController Controller
    {
        get { return controller; }
    }

    private void Start()
    {
        mainView = GetComponent<MainView>();
        mainView.UpdateInfo(PlayerModel.Data);

        mainView.btnRole.onClick.AddListener(ClickRole);

        PlayerModel.Data.AddEventListener(UpdateUIInfo);
    }

    private void UpdateUIInfo(PlayerModel playerModel)
    {
        mainView?.UpdateInfo(playerModel);
    }

    private void ClickRole()
    {
        RoleController.ShowMe();
    }

    public static void ShowMe()
    {
        if (!controller)
        {
            var res = Resources.Load<GameObject>("UI/MainPanel");
            var obj = Instantiate(res, GameObject.Find("Canvas").transform);
            controller = obj.GetComponent<MainController>();
        }

        controller.gameObject.SetActive(true);
    }

    public static void HideMe()
    {
        if (controller)
        {
            controller.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        PlayerModel.Data.RemoveEventListerner(UpdateUIInfo);
    }
}