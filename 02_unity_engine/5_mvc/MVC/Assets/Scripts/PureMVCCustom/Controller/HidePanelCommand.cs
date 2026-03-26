using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using PureMVC.Patterns.Mediator;
using UnityEngine;

namespace PureMVCCustom.Controller
{
    public class HidePanelCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);

            if (notification.Body is Mediator { ViewComponent: not null } m)
            {
                Object.Destroy((m.ViewComponent as MonoBehaviour)?.gameObject);
                m.ViewComponent = null;
            }
        }
    }
}