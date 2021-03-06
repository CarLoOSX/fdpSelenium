using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MdasFdpPractica3.Dto;
using MdasFdpPractica3.Enum;
using MdasFdpPractica3.WebPages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MdasFdpPractica3.Steps
{
    [Binding]
    public class InitialSearchSteps
    {
        private readonly SearchPage _searchPage;


        public InitialSearchSteps(SearchPage searchPage)
        {
            _searchPage = searchPage;
        }

        [Given(@"I'm in main page")]
        public void GivenImInMainPage()
        {
            _searchPage.GoToSearchMainPage();
        }

        [When(@"I try to find a flight")]
        public void WhenITryToFindAFlight(Table table)
        {
            var request = table.CreateInstance<SearchFlightDto>();

            _searchPage.AddOrigin(request.Origin);

            _searchPage.AddDestination(request.Destination);

            _searchPage.AddOutbound(GetFormattedDate(request.Outbound));

            _searchPage.AddPassengers(request.Passengers);

            _searchPage.Search();
        }

        [Then(@"I get available flight")]
        public void ThenIGetAvailableFlight()
        {

        }

        private string GetFormattedDate(DatesEnum requestOutbound)
        {
            DateTime date;
            switch (requestOutbound)
            {
                case DatesEnum.NEXT_WEEK:
                    date = DateTime.Today.AddDays(7);
                    break;
                case DatesEnum.TODAY:
                    date = DateTime.Today;
                    break;
                case DatesEnum.TOMORROW:
                    date = DateTime.Today.AddDays(1);
                    break;
                case DatesEnum.YESTERDAY:
                    date = DateTime.Today.AddDays(-1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(requestOutbound), requestOutbound, null);
            }

            return date.ToString("dd/MM/yyyy");
        }
    }
}