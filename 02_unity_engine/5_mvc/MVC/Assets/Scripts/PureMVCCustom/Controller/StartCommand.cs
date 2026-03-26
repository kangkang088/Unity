using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using PureMVCCustom.Model;
using UnityEngine;

namespace PureMVCCustom.Controller
{
    public class StartCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);

            Debug.Log("123");
            if (!Facade.HasProxy(PlayerProxy.NAME))
                Facade.RegisterProxy(new PlayerProxy());
        }
    }
}