using System;
using PureMVC;
using PureMVCCustom.View;
using UnityEngine;

namespace PureMVCCustom
{
    public class Main : MonoBehaviour
    {
        private void Start()
        {
            GameFacade.Instance.StartUp();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                GameFacade.Instance.SendNotification(PureNotification.SHOW_PANEL, "MainPanel");
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                GameFacade.Instance.SendNotification(PureNotification.HIDE_PANEL,
                    GameFacade.Instance.RetrieveMediator(NewMainViewMediator.NAME));
            }
        }
    }
}