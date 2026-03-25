using PureMVC.Patterns.Proxy;
using UnityEngine;

namespace PureMVCCustom.Model
{
    /// <summary>
    /// 玩家数据代理对象
    /// 主要处理 玩家数据 更新相关逻辑
    /// </summary>
    public class PlayerProxy : Proxy
    {
        public new const string NAME = "PlayerProxy";

        public PlayerProxy() : base(NAME)
        {
            var data = new PlayerDataObj
            {
                playerName = PlayerPrefs.GetString("PlayerName", "Player1"),
                level = PlayerPrefs.GetInt("PlayerLevel", 1),
                gold = PlayerPrefs.GetInt("PlayerGold", 1000),
                diamond = PlayerPrefs.GetInt("PlayerDiamond", 500),
                power = PlayerPrefs.GetInt("PlayerPower", 60),
                hp = PlayerPrefs.GetInt("PlayerHp", 100),
                atk = PlayerPrefs.GetInt("PlayerAtk", 20),
                def = PlayerPrefs.GetInt("PlayerDef", 10),
                crit = PlayerPrefs.GetInt("PlayerCrit", 20),
                miss = PlayerPrefs.GetInt("PlayerMiss", 10),
                lucky = PlayerPrefs.GetInt("PlayerLucky", 5)
            };

            Data = data;
        }

        public void LevelUp()
        {
            if (Data is PlayerDataObj data)
            {
                data.level += 1;
                data.hp += data.level;
                data.atk += data.level;
                data.def += data.level;
                data.crit += data.level;
                data.miss += data.level;
                data.lucky += data.level;
            }

            SaveData();
        }

        private void SaveData()
        {
            if (Data is PlayerDataObj data)
            {
                PlayerPrefs.SetString("PlayerName", data.playerName);
                PlayerPrefs.SetInt("PlayerLevel", data.level);
                PlayerPrefs.SetInt("PlayerGold", data.gold);
                PlayerPrefs.SetInt("PlayerDiamond", data.diamond);
                PlayerPrefs.SetInt("PlayerPower", data.power);
                PlayerPrefs.SetInt("PlayerHp", data.hp);
                PlayerPrefs.SetInt("PlayerAtk", data.atk);
                PlayerPrefs.SetInt("PlayerDef", data.def);
                PlayerPrefs.SetInt("PlayerCrit", data.crit);
                PlayerPrefs.SetInt("PlayerMiss", data.miss);
                PlayerPrefs.SetInt("PlayerLucky", data.lucky);
            }
        }
    }
}