using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveSelectionServer
{
    /// <summary>
    /// Read the appsettings from App.config file.
    /// </summary>
    public static class Settings
    {
        public static string DataFilePath => ConfigurationSettings.AppSettings.Get("DataFilePath").ToString();
        public static int TcpPort => Convert.ToInt32(ConfigurationSettings.AppSettings.Get("Port"));       
    }
}
