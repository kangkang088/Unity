using PureMVC;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using PureMVCCustom.Model;
using PureMVCCustom.View;
using UnityEngine;

namespace PureMVCCustom.Controller
{
    public class ShowPanelCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);

            var panelName = notification.Body;

            Debug.Log(panelName);

            switch (panelName)
            {
                case "MainPanel":
                    if (!Facade.HasMediator(NewMainViewMediator.NAME))
                        Facade.RegisterMediator(new NewMainViewMediator());

                    var mm = (NewMainViewMediator)Facade.RetrieveMediator(NewMainViewMediator.NAME);
                    if (mm.ViewComponent == null)
                    {
                        var res = Resources.Load<GameObject>("UI/MainPanel");
                        var obj = Object.Instantiate(res, GameObject.Find("Canvas").transform);
                        mm.SetView(obj.GetComponent<NewMainView>());
                    }

                    SendNotification(PureNotification.UPDATE_PLAYER_INFO, Facade.RetrieveProxy(PlayerProxy.NAME).Data);

                    break;
                case "RolePanel":
                    if (!Facade.HasMediator(NewRoleViewMediator.NAME))
                        Facade.RegisterMediator(new NewRoleViewMediator());

                    var rmm = (NewRoleViewMediator)Facade.RetrieveMediator(NewRoleViewMediator.NAME);
                    if (rmm.ViewComponent == null)
                    {
                        var res = Resources.Load<GameObject>("UI/RolePanel");
                        var obj = Object.Instantiate(res, GameObject.Find("Canvas").transform);
                        rmm.SetView(obj.GetComponent<NewRoleView>());
                    }

                    SendNotification(PureNotification.UPDATE_PLAYER_INFO, Facade.RetrieveProxy(PlayerProxy.NAME).Data);

                    break;
            }
        }
    }
}