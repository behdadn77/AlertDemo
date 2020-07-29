﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertDemo.Controllers
{
    public class ControllerCustom : Controller
    {
        public enum alerts
        { 
            Success,
            Warning,
            Error,
            Info
        }

        public void SendAlert(string key,alerts alerts)
        {
            switch (alerts)
            {
                case alerts.Success:
                    TempData["GlobalSuccess"] = AlertLib.SelectAlert.Success[key];
                    break;
                case alerts.Warning:
                    TempData["GlobalWarning"] = AlertLib.SelectAlert.Warning[key];
                    break;
                case alerts.Error:
                    TempData["GlobalError"] = AlertLib.SelectAlert.Error[key];
                    break;
                case alerts.Info:
                    TempData["GlobalInfo"] = AlertLib.SelectAlert.Info[key];
                    break;
                default:
                    break;
            }
        }
    }
}
