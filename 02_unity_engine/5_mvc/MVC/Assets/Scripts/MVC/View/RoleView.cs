using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleView : MonoBehaviour
{
    public Button btnLevelUp;
    public Button btnClose;

    public Text textLevel;
    public Text textHp;
    public Text textAtk;
    public Text textDef;
    public Text textCrit;
    public Text textMiss;
    public Text textLucky;

    public void UpdateInfo(PlayerModel playerModel)
    {
        textLevel.text = "LV." + playerModel.Level;
        textHp.text = playerModel.HP.ToString();
        textAtk.text = playerModel.Atk.ToString();
        textDef.text = playerModel.Def.ToString();
        textCrit.text = playerModel.Crit.ToString();
        textMiss.text = playerModel.Miss.ToString();
        textLucky.text = playerModel.Lucky.ToString();
    }
}