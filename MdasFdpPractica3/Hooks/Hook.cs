using System;
using BoDi;
using MdasFdpPractica3.Services;
using MdasFdpPractica3.Services.Contracts;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace MdasFdpPractica3.Hooks
{
    [Binding]
    public class Hook
    {
        private readonly IObjectContainer _objectContainer;

        public Hook(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(10);
            _objectContainer.RegisterInstanceAs<IWebDriverService>(new SeleniumWebDriverService(webDriver));
        }
    }
}