using UnityEngine;
using UnityEngine.Events;

public class PlayerModel
{
    private string playerName;

    public string PlayerName
    { get { return playerName; } }

    private int level;

    public int Level
    { get { return level; } }

    private int gold;

    public int Gold
    { get { return gold; } }

    private int diamond;

    public int Diamond
    { get { return diamond; } }

    private int power;

    public int Power
    { get { return power; } }

    private int hp;

    public int HP
    { get { return hp; } }

    private int atk;

    public int Atk
    { get { return atk; } }

    private int def;

    public int Def
    { get { return def; } }

    private int crit;

    public int Crit
    { get { return crit; } }

    private int miss;

    public int Miss
    { get { return miss; } }

    private int lucky;

    public int Lucky
    { get { return lucky; } }

    private event UnityAction<PlayerModel> UpdateInfoEvent;

    private static PlayerModel data = null;

    public static PlayerModel Data
    {
        get
        {
            if (data == null)
            {
                data = new PlayerModel();
                data.Init();
            }

            return data;
        }
    }

    public void Init()
    {
        playerName = PlayerPrefs.GetString("PlayerName", "Player1");
        level = PlayerPrefs.GetInt("PlayerLevel", 1);
        gold = PlayerPrefs.GetInt("PlayerGold", 1000);
        diamond = PlayerPrefs.GetInt("PlayerDiamond", 500);
        power = PlayerPrefs.GetInt("PlayerPower", 60);

        hp = PlayerPrefs.GetInt("PlayerHp", 100);
        atk = PlayerPrefs.GetInt("PlayerAtk", 20);
        def = PlayerPrefs.GetInt("PlayerDef", 10);
        crit = PlayerPrefs.GetInt("PlayerCrit", 20);
        miss = PlayerPrefs.GetInt("PlayerMiss", 10);
        lucky = PlayerPrefs.GetInt("PlayerLucky", 5);
    }

    public void LevelUp()
    {
        level += 1;
        hp += level;
        atk += level;
        def += level;
        crit += level;
        miss += level;
        lucky += level;

        SaveData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("PlayerGold", gold);
        PlayerPrefs.SetInt("PlayerDiamond", diamond);
        PlayerPrefs.SetInt("PlayerPower", power);

        PlayerPrefs.SetInt("PlayerHp", hp);
        PlayerPrefs.SetInt("PlayerLevel", level);
        PlayerPrefs.SetInt("PlayerAtk", atk);
        PlayerPrefs.SetInt("PlayerDef", def);
        PlayerPrefs.SetInt("PlayerCrit", crit);
        PlayerPrefs.SetInt("PlayerMiss", miss);
        PlayerPrefs.SetInt("PlayerLucky", lucky);

        UpdateInfo();
    }

    public void AddEventListener(UnityAction<PlayerModel> callback)
    {
        UpdateInfoEvent += callback;
    }

    public void RemoveEventListerner(UnityAction<PlayerModel> callback)
    {
        UpdateInfoEvent -= callback;
    }

    private void UpdateInfo()
    {
        if (UpdateInfoEvent != null)
        {
            UpdateInfoEvent.Invoke(this);
        }
    }
}