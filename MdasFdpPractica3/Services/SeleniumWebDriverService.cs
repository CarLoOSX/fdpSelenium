using MdasFdpPractica3.Services.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace MdasFdpPractica3.Services
{
    public class SeleniumWebDriverService : IWebDriverService
    {
        private readonly RemoteWebDriver _webDriver;

        public SeleniumWebDriverService(RemoteWebDriver webDriver)
        {
            _webDriver = webDriver;

        }

        public string GoToPage(string url)
        {
            return _webDriver.Url = url;
        }

        public IWebElement FindElementById(string id)
        {
            return _webDriver.FindElementById(id);
        }

        public IWebElement FindElementByXPath(string xpath)
        {
            return _webDriver.FindElementByXPath(xpath);
        }

        public void ExecuteScript(string script)
        {
            _webDriver.ExecuteScript(script);
        }
    }
}