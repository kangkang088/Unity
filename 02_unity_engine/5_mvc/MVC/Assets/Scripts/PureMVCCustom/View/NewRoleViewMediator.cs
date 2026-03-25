using PureMVC;
using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using PureMVCCustom.Model;

namespace PureMVCCustom.View
{
    public class NewRoleViewMediator : Mediator
    {
        public new static string NAME = "NewRoleViewMediator";

        public NewRoleViewMediator() : base(NAME)
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
                    if (ViewComponent is NewRoleView newRoleView)
                    {
                        newRoleView.UpdateInfo(notification.Body as PlayerDataObj);
                    }

                    break;
            }
        }
    }
}