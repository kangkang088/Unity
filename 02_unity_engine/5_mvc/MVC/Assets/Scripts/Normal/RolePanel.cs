using UnityEngine;
using UnityEngine.UI;

public class RolePanel : MonoBehaviour
{
    public Text textLevel;
    public Text textHp;
    public Text textAtk;
    public Text textDef;
    public Text textCrit;
    public Text textMiss;
    public Text textLucky;

    public Button btnClose;
    public Button btnLevUp;

    public static RolePanel _rolePanel;

    private void Start()
    {
        btnClose.onClick.AddListener(ClickClose);
        btnLevUp.onClick.AddListener(ClickLevUp);
    }

    private void ClickLevUp()
    {
        Debug.Log("Level Up");
        var hp = PlayerPrefs.GetInt("PlayerHp", 100);
        var lev = PlayerPrefs.GetInt("PlayerLevel", 1);
        var atk = PlayerPrefs.GetInt("PlayerAtk", 20);
        var def = PlayerPrefs.GetInt("PlayerDef", 10);
        var crit = PlayerPrefs.GetInt("PlayerCrit", 20);
        var miss = PlayerPrefs.GetInt("PlayerMiss", 10);
        var lucky = PlayerPrefs.GetInt("PlayerLucky", 5);

        lev += 1;
        hp += lev;
        atk += lev;
        def += lev;
        crit += lev;
        miss += lev;
        lucky += lev;

        PlayerPrefs.SetInt("PlayerHp", hp);
        PlayerPrefs.SetInt("PlayerLevel", lev);
        PlayerPrefs.SetInt("PlayerAtk", atk);
        PlayerPrefs.SetInt("PlayerDef", def);
        PlayerPrefs.SetInt("PlayerCrit", crit);
        PlayerPrefs.SetInt("PlayerMiss", miss);
        PlayerPrefs.SetInt("PlayerLucky", lucky);

        UpdateInfo();
        
        MainPanel.Panel.UpdateInfo();
    }

    private void ClickClose()
    {
        Debug.Log("Close");
        HideMe();
    }

    public void UpdateInfo()
    {
        textLevel.text = "LV." + PlayerPrefs.GetInt("PlayerLevel", 1);
        textHp.text = PlayerPrefs.GetInt("PlayerHp", 100).ToString();
        textAtk.text = PlayerPrefs.GetInt("PlayerAtk", 20).ToString();
        textDef.text = PlayerPrefs.GetInt("PlayerDef", 10).ToString();
        textCrit.text = PlayerPrefs.GetInt("PlayerCrit", 20).ToString();
        textMiss.text = PlayerPrefs.GetInt("PlayerMiss", 10).ToString();
        textLucky.text = PlayerPrefs.GetInt("PlayerLucky", 5).ToString();
    }

    public static void ShowMe()
    {
        if (!_rolePanel)
        {
            _rolePanel = Instantiate(Resources.Load<GameObject>("UI/RolePanel"), GameObject.Find("Canvas").transform).GetComponent<RolePanel>();
        }

        _rolePanel.gameObject.SetActive(true);
        _rolePanel.UpdateInfo();
    }

    public static void HideMe()
    {
        if (_rolePanel)
        {
            _rolePanel.gameObject.SetActive(false);
        }
    }
}