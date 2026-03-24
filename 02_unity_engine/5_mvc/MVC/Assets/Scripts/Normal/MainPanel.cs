using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    public Text textName;
    public Text textLevel;
    public Text textGold;
    public Text textDiamond;
    public Text textPower;

    public Button btnRole;

    private static MainPanel _panel;

    public static MainPanel Panel
    {
        get { return _panel; }
    }

    private void Start()
    {
        btnRole.onClick.AddListener(ClickButtonRole);
    }

    private void ClickButtonRole()
    {
        // 打开角色面板逻辑
        Debug.Log("open role panel.");
        RolePanel.ShowMe();
    }

    public void UpdateInfo()
    {
        // 更新信息
        textName.text = PlayerPrefs.GetString("PlayerName", "Player1");
        textLevel.text = "LV." + PlayerPrefs.GetInt("PlayerLevel", 1);
        textGold.text = PlayerPrefs.GetInt("PlayerGold", 1000).ToString();
        textDiamond.text = PlayerPrefs.GetInt("PlayerDiamond", 500).ToString();
        textPower.text = PlayerPrefs.GetInt("PlayerPower", 60).ToString();
    }

    public static void ShowMe()
    {
        if (!_panel)
        {
            var res = Resources.Load<GameObject>("UI/MainPanel");
            var obj = Instantiate(res, GameObject.Find("Canvas").transform);
            _panel = obj.GetComponent<MainPanel>();
        }

        _panel.gameObject.SetActive(true);
        _panel.UpdateInfo();
    }

    public static void HideMe()
    {
        if (_panel)
        {
            // Destroy(_panel.gameObject);
            // _panel = null;
            _panel.gameObject.SetActive(false);
        }
    }
}