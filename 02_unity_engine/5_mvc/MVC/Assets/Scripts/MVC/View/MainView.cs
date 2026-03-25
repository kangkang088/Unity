using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    public Button btnRole;
    public Button btnSkill;

    public Text textName;
    public Text textLevel;
    public Text textGold;
    public Text textDiamond;
    public Text textPower;

    public void UpdateInfo(PlayerModel playerModel)
    {
        textName.text = playerModel.PlayerName;
        textLevel.text = "LV." + playerModel.Level.ToString();
        textGold.text = playerModel.Gold.ToString();
        textDiamond.text = playerModel.Diamond.ToString();
        textPower.text = playerModel.Power.ToString();
    }
}