using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolePresenter : MonoBehaviour
{
    private MVP_RoleView roleView;

    private static RolePresenter presenter = null;

    public static RolePresenter Presenter
    {
        get { return presenter; }
    }

    private void Start()
    {
        roleView = GetComponent<MVP_RoleView>();

        //roleView.UpdateInfo(PlayerModel.Data);
        UpdateUIInfo(PlayerModel.Data);

        roleView.btnClose.onClick.AddListener(ClickClose);
        roleView.btnLevelUp.onClick.AddListener(ClickLevelUp);

        PlayerModel.Data.AddEventListener(UpdateUIInfo);
    }

    private void UpdateUIInfo(PlayerModel playerModel)
    {
        //roleView?.UpdateInfo(playerModel);  \
        if (playerModel == null) return;

        roleView.textLevel.text = "LV." + playerModel.Level;
        roleView.textHp.text = playerModel.HP.ToString();
        roleView.textAtk.text = playerModel.Atk.ToString();
        roleView.textDef.text = playerModel.Def.ToString();
        roleView.textCrit.text = playerModel.Crit.ToString();
        roleView.textMiss.text = playerModel.Miss.ToString();
        roleView.textLucky.text = playerModel.Lucky.ToString();
    }

    private void ClickLevelUp()
    {
        PlayerModel.Data.LevelUp();
    }

    private void ClickClose()
    {
        HideMe();
    }

    public static void ShowMe()
    {
        if (!presenter)
        {
            var res = Resources.Load<GameObject>("UI/RolePanel");
            var obj = Instantiate(res, GameObject.Find("Canvas").transform);
            presenter = obj.GetComponent<RolePresenter>();
        }

        presenter.gameObject.SetActive(true);
    }

    public static void HideMe()
    {
        if (presenter)
        {
            presenter.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        PlayerModel.Data.RemoveEventListerner(UpdateUIInfo);
    }
}