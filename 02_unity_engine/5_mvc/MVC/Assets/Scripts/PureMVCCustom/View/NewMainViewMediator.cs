using PureMVC;
using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using PureMVCCustom.Model;

namespace PureMVCCustom.View
{
    public class NewMainViewMediator : Mediator
    {
        public new static string NAME = "NewMainViewMediator";

        public NewMainViewMediator() : base(NAME)
        {
        }

        public override string[] ListNotificationInterests()
        {
            return new[] { PureNotification.UPDATE_PLAYER_INFO };
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case PureNotification.UPDATE_PLAYER_INFO:
                    if (ViewComponent is NewMainView newMainView)
                    {
                        newMainView.UpdateInfo(notification.Body as PlayerDataObj);
                    }

                    break;
            }
        }

        public override void OnRegister()
        {
            base.OnRegister();
        }

        public void SetView(NewMainView newMainView)
        {
            ViewComponent = newMainView;
            newMainView.btnRole.onClick.AddListener(() =>
            {
                GameFacade.Instance.SendNotification(PureNotification.SHOW_PANEL, "RolePanel");
            });
        }
    }
}