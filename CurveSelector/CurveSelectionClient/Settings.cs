using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveSelectionClient
{
    /// <summary>
    /// Read the appsettings from App.config file.
    /// </summary>
    public static class Settings
    {
        public static string IpAddress => ConfigurationSettings.AppSettings.Get("IpAddress");
        public static int TcpPort => Convert.ToInt32(ConfigurationSettings.AppSettings.Get("Port"));
        public static string DownloadPath => ConfigurationSettings.AppSettings.Get("DownloadPath");
        public static string FileExtension => ConfigurationSettings.AppSettings.Get("FileExtension");
    }
}
