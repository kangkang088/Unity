using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP_MainPanel : BasePanel
{
    private void Start()
    {
        UpdateInfo(PlayerModel.Data);

        // PlayerModel.Data.AddEventListener(UpdateInfo);

        //MVE
        EventCenter.GetInstance().AddEventListener<PlayerModel>("玩家数据", UpdateInfo);
    }

    protected override void OnClick(string btnName)
    {
        base.OnClick(btnName);

        switch (btnName)
        {
            case "btnRole":
                UIManager.GetInstance().ShowPanel<MP_RolePanel>("RolePanel");
                break;
        }
    }

    private void UpdateInfo(PlayerModel playerModel)
    {
        GetControl<Text>("txtName").text = playerModel.PlayerName;
        GetControl<Text>("txtLev").text = "LV." + playerModel.Level;
        GetControl<Text>("txtMoney").text = playerModel.Gold.ToString();
        GetControl<Text>("txtGem").text = playerModel.Diamond.ToString();
        GetControl<Text>("txtPower").text = playerModel.Power.ToString();
    }

    private void OnDestroy()
    {
        // PlayerModel.Data.RemoveEventListerner(UpdateInfo);

        EventCenter.GetInstance().RemoveEventListener<PlayerModel>("玩家数据", UpdateInfo);
    }
}