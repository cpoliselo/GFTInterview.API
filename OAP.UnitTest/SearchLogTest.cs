using OAP.Api.Controllers;
using System;
using Xunit;
using Bogus;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using OAPoliselo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace OAP.UnitTest
{
    public class SearchLogTest
    {
        private readonly SearchLogController controller;

        public SearchLogTest()
        {
            controller = new SearchLogController();
        }

        [Fact]
        public void SearchLog_Get_By_All_Should_Be_Ok()
        {
            //Chamada para a web API
            var searchLog = controller.Get();

            //Valida o tipo da resosta com FluentAssertations
            searchLog.Should().BeOfType<OkObjectResult>();
        }      
    }
}
