﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using static AlertLib.Model.AlertsModel;

namespace AlertLib
{
    public class SelectAlert
    {
        public static Dictionary<string, string> Success = new Dictionary<string, string>();
        public static Dictionary<string, string> Warning = new Dictionary<string, string>();
        public static Dictionary<string, string> Error = new Dictionary<string, string>();
        public static Dictionary<string, string> Info = new Dictionary<string, string>();

        public static void Initialize()
        {
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).FullName, @"AlertLib\alerts.json");
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                Alerts alerts = JsonConvert.DeserializeObject<Alerts>(json);
                foreach (JObject obj in alerts.AlertTypes.Success)
                {
                    foreach (JProperty props in obj.Properties())
                    {
                        Success.Add(props.Name, (string)props.Value);
                    }
                }
                foreach (JObject obj in alerts.AlertTypes.Warning)
                {
                    foreach (JProperty props in obj.Properties())
                    {
                        Warning.Add(props.Name, (string)props.Value);
                    }
                }
                foreach (JObject obj in alerts.AlertTypes.Error)
                {
                    foreach (JProperty props in obj.Properties())
                    {
                        Error.Add(props.Name, (string)props.Value);
                    }
                }
                foreach (JObject obj in alerts.AlertTypes.Info)
                {
                    foreach (JProperty props in obj.Properties())
                    {
                        Info.Add(props.Name, (string)props.Value);
                    }
                }
            }
        }
    }
}
