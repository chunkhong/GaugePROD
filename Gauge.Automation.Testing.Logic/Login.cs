using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Gauge.Automation.Testing.Logic
{
    public class Login
    {
        public bool isSuccessfullLogin(string username, string password,string loginUrl)
        {
            IWebDriver driver = new ChromeDriver();

            return true;
        }
    }
}
