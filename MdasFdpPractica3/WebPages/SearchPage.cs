using System;
using System.Collections.Generic;
using System.Linq;
using MdasFdpPractica3.Services.Contracts;
using MdasFdpPractica3.WebPages.Base;
using OpenQA.Selenium;

namespace MdasFdpPractica3.WebPages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriverService webDriverService) : base(webDriverService)
        {

        }

        private IWebElement Origin => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-airport-selector[1]/div/input");

        private IWebElement Destination => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-airport-selector[2]/div/input");

        private IWebElement StartDate => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-datepicker-selector/div[1]/div/input");

        private IWebElement EndDate => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-datepicker-selector/div[1]/div/input");

        private IWebElement Passengers => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-pax-selector/div/input");

        private IWebElement ButtonCookies => WebDriverService.FindElementByXPath("//*[@id=\"ensCloseBanner\"]");

        private IWebElement List => WebDriverService.FindElementByXPath("//*[@id=\"popup-list\"]");

        private IWebElement FlightSelector => WebDriverService.FindElementByXPath("//*[@id=\"searchbar\"]/div/vy-datepicker-popup/vy-datepicker-header/ul");

        private IWebElement SingleFlightInput => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-datepicker-selector/div[1]/div/input");

        private IWebElement AddMorePassengersButton => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-pax-selector/vy-pax-popup/ul/li[1]/vy-type-pax/div[2]/span[2]");

        private IWebElement PassengersValue => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-pax-selector/vy-pax-popup/ul/li[1]/vy-type-pax/div[2]/div");

        private IWebElement PassengersSelector => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-pax-selector");

        private IWebElement SearchButton => WebDriverService.FindElementByXPath("//*[@id=\"btnSubmitHomeSearcher\"]");

        public void GoToSearchMainPage()
        {
            WebDriverService.GoToPage("https://www.vueling.com/es");

            if (ButtonCookies == null) return;


            ButtonCookies.Click();

        }

        public void AddOrigin(string origin)
        {
            Origin.Click();

            SearchInCountriesList(origin);

        }

        private void SearchInCountriesList(string origin)
        {
            bool found = false;

            var countriesList = List.FindElements(By.TagName("li"));

            foreach (var country in countriesList)
            {
                //to avoid get something that does not exist after country selection
                //list will not be available
                if (found) break;

                var abreviations = country.FindElements(By.TagName("p"));

                foreach (var abreviation in abreviations)
                {

                    if (abreviation.Text == origin)
                    {
                        country.Click();
                        //to avoid get something that does not exist after country selection
                        //list will not be available
                        found = true;
                        break;

                    }

                }
            }
        }

        public void AddDestination(string destination)
        {
            Destination.Click();

            SearchInCountriesList(destination);
        }

        public void AddOutbound(string time)
        {
            var options = FlightSelector.FindElements(By.TagName("li"));

            //solo ida
            options[1].Click();

            WebDriverService.ExecuteScript($"document.querySelector(\"#tab-search > div > div.form-group.form-group--flight-search > vy-datepicker-selector > div:nth-child(1) > div > input\").value = \"{time}\"");

        }

        public void AddReturn(string time)
        {
            throw new NotImplementedException();
        }

        public void AddPassengers(int passengers)
        {

            AddPassengersRecursively(passengers.ToString());
        }

        private void AddPassengersRecursively(string passengers)
        {
            PassengersSelector.Click();

            if (PassengersValue.Text == passengers) return;

            AddMorePassengersButton.Click();

            AddPassengersRecursively(passengers);

        }

        public void Search()
        {
            SearchButton.Click();
        }
    }
}