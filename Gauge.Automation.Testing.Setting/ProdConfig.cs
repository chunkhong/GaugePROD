using System.Configuration;

namespace Gauge.Automation.Testing.Setting
{
    public static class ProdConfig
    {
        public  static string LoginUrl = ConfigurationManager.AppSettings["LoginProdUrl"];
    }
}
