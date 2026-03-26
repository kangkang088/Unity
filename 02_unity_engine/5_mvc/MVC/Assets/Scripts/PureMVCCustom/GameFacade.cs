using PureMVC;
using PureMVC.Patterns.Facade;
using PureMVCCustom.Controller;

namespace PureMVCCustom
{
    public class GameFacade : Facade
    {
        public static GameFacade Instance
        {
            get
            {
                instance ??= new GameFacade();

                return instance as GameFacade;
            }
        }

        protected override void InitializeController()
        {
            base.InitializeController();

            RegisterCommand(PureNotification.START_UP, () => new StartCommand());

            RegisterCommand(PureNotification.SHOW_PANEL, () => new ShowPanelCommand());

            RegisterCommand(PureNotification.HIDE_PANEL, () => new HidePanelCommand());

            RegisterCommand(PureNotification.LEVEL_UP, () => new LevelUpCommand());
        }

        public void StartUp()
        {
            SendNotification(PureNotification.START_UP);

            // SendNotification(PureNotification.SHOW_PANEL, "MainPanel");
        }
    }
}