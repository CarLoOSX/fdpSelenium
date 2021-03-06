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
            StartDate.SendKeys(time);
        }

        public void AddReturn(string time)
        {
            EndDate.SendKeys(time);
        }

        public void AddPassengers(int passengers)
        {
            Passengers.SendKeys(passengers.ToString());
        }


        public class Search
        {
            public string Origin { get; set; }
            public string Destination { get; set; }
            public DateTime Outbound { get; set; }
            public string Return { get; set; }
            public int Passengers { get; set; }
        }
    }
}