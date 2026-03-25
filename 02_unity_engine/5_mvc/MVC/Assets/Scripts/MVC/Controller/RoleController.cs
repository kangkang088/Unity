using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleController : MonoBehaviour
{
    private RoleView roleView;

    private static RoleController controller = null;

    public static RoleController Controller
    {
        get { return controller; }
    }

    private void Start()
    {
        roleView = GetComponent<RoleView>();
        roleView.UpdateInfo(PlayerModel.Data);

        roleView.btnClose.onClick.AddListener(ClickClose);

        roleView.btnLevelUp.onClick.AddListener(ClickLevelUp);

        PlayerModel.Data.AddEventListener(UpdateUIInfo);
    }

    private void UpdateUIInfo(PlayerModel playerModel)
    {
        roleView?.UpdateInfo(playerModel);
    }

    private void ClickLevelUp()
    {
        PlayerModel.Data.LevelUp();
    }

    private void ClickClose()
    {
        HideMe();
    }

    public static void ShowMe()
    {
        if (!controller)
        {
            var res = Resources.Load<GameObject>("UI/RolePanel");
            var obj = Instantiate(res, GameObject.Find("Canvas").transform);
            controller = obj.GetComponent<RoleController>();
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