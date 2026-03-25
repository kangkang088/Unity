using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPresenter : MonoBehaviour
{
    private MVP_MainView mainView;

    private static MainPresenter persenter;

    public static MainPresenter Persenter
    {
        get { return persenter; }
    }

    private void Start()
    {
        mainView = GetComponent<MVP_MainView>();

        //mainView.UpdateInfo(PlayerModel.Data);
        UpdateUIInfo(PlayerModel.Data);

        mainView.btnRole.onClick.AddListener(ClickRole);

        PlayerModel.Data.AddEventListener(UpdateUIInfo);
    }

    private void UpdateUIInfo(PlayerModel playerModel)
    {
        //mainView?.UpdateInfo(playerModel);   // 不在view中更新model了，断开view和model联系，让presenter来做

        if (playerModel == null) return;
        mainView.textName.text = playerModel.PlayerName;
        mainView.textLevel.text = "LV." + playerModel.Level.ToString();
        mainView.textGold.text = playerModel.Gold.ToString();
        mainView.textDiamond.text = playerModel.Diamond.ToString();
        mainView.textPower.text = playerModel.Power.ToString();
    }

    private void ClickRole()
    {
        RolePresenter.ShowMe();
    }

    public static void ShowMe()
    {
        if (!persenter)
        {
            var res = Resources.Load<GameObject>("UI/MainPanel");
            var obj = Instantiate(res, GameObject.Find("Canvas").transform);
            persenter = obj.GetComponent<MainPresenter>();
        }

        persenter.gameObject.SetActive(true);
    }

    public static void HideMe()
    {
        if (persenter)
        {
            persenter.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        PlayerModel.Data.RemoveEventListerner(UpdateUIInfo);
    }
}