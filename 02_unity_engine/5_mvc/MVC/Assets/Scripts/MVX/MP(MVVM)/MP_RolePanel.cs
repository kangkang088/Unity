using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP_RolePanel : BasePanel
{
    private void Start()
    {
        UpdateInfo(PlayerModel.Data);

        PlayerModel.Data.AddEventListener(UpdateInfo);
    }

    protected override void OnClick(string btnName)
    {
        base.OnClick(btnName);

        switch (btnName)
        {
            case "btnLevUp":
                PlayerModel.Data.LevelUp();
                break;

            case "btnClose":
                UIManager.GetInstance().HidePanel("RolePanel");
                break;
        }
    }

    public void UpdateInfo(PlayerModel playerModel)
    {
        GetControl<Text>("txtLev").text = "LV." + playerModel.Level;
        GetControl<Text>("txtHp").text = playerModel.HP.ToString();
        GetControl<Text>("txtAtk").text = playerModel.Atk.ToString();
        GetControl<Text>("txtDef").text = playerModel.Def.ToString();
        GetControl<Text>("txtCrit").text = playerModel.Crit.ToString();
        GetControl<Text>("txtMiss").text = playerModel.Miss.ToString();
        GetControl<Text>("txtLuck").text = playerModel.Lucky.ToString();
    }

    private void OnDestroy()
    {
        PlayerModel.Data.RemoveEventListerner(UpdateInfo);
    }
}