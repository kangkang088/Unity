using PureMVCCustom.Model;
using UnityEngine;
using UnityEngine.UI;

namespace PureMVCCustom.View
{
    public class NewMainView : MonoBehaviour
    {
        public Button btnRole;
        public Button btnSkill;

        public Text textName;
        public Text textLevel;
        public Text textGold;
        public Text textDiamond;
        public Text textPower;

        public void UpdateInfo(PlayerDataObj playerDataObj)
        {
            textName.text = playerDataObj.playerName;
            textLevel.text = "LV." + playerDataObj.level;
            textGold.text = playerDataObj.gold.ToString();
            textDiamond.text = playerDataObj.diamond.ToString();
            textPower.text = playerDataObj.power.ToString();
        }
    }
}