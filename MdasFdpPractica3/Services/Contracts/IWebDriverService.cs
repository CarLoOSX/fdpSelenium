using OpenQA.Selenium;

namespace MdasFdpPractica3.Services.Contracts
{
    public interface IWebDriverService
    {
        string GoToPage(string url);
        IWebElement FindElementById(string id);
        IWebElement FindElementByXPath(string xpath);
        void ExecuteScript(string script);
    }
}