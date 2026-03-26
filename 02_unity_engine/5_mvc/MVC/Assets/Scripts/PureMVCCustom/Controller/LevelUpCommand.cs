using PureMVC;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using PureMVCCustom.Model;

namespace PureMVCCustom.Controller
{
    public class LevelUpCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);

            if (Facade.RetrieveProxy(PlayerProxy.NAME) is PlayerProxy p)
            {
                p.LevelUp();
                SendNotification(PureNotification.UPDATE_PLAYER_INFO, p.Data);
            }
        }
    }
}