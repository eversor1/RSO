using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using Newtonsoft.Json;



namespace RSO
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string ServicesOrder = File.ReadAllText("services.json");
            Newtonsoft.Json.Linq.JObject config = Newtonsoft.Json.Linq.JObject.Parse(ServicesOrder);
            //ServiceOperations ServicesFile = JsonConvert.DeserializeObject<configSchema>(ServicesOrder);
            string output = JsonConvert.SerializeObject(config);
            //System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStart.txt");
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "OnStart.txt", (string)config);
        }

        protected override void OnStop()
        {
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStop.txt");
        }
    }

    public class ServiceOperations {
        string Name;
        int Priority;
    }
}
