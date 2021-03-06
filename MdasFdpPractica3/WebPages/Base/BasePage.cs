using MdasFdpPractica3.Services.Contracts;
using OpenQA.Selenium;

namespace MdasFdpPractica3.WebPages.Base
{
    public class BasePage
    {
        protected readonly IWebDriverService WebDriverService;

        public BasePage(IWebDriverService webDriverService)
        {
            WebDriverService = webDriverService;
        }

        private string GotoPage(string url)
        {
            return WebDriverService.GoToPage(url);
        }
    }
}