using PureMVCCustom.Model;
using UnityEngine;
using UnityEngine.UI;

namespace PureMVCCustom.View
{
    public class NewRoleView : MonoBehaviour
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

        public void UpdateInfo(PlayerDataObj playerDataObj)
        {
            textLevel.text = "LV." + playerDataObj.level;
            textHp.text = playerDataObj.hp.ToString();
            textAtk.text = playerDataObj.atk.ToString();
            textDef.text = playerDataObj.def.ToString();
            textCrit.text = playerDataObj.crit.ToString();
            textMiss.text = playerDataObj.miss.ToString();
            textLucky.text = playerDataObj.lucky.ToString();
        }
    }
}