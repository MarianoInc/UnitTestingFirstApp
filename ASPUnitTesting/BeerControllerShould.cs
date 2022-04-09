using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UnitTestinFirstApp.API.Controllers;
using UnitTestinFirstApp.API.Models;
using UnitTestinFirstApp.API.Services;
using Xunit;

namespace ASPUnitTesting
{
    public class BeerControllerShould
    {
        private readonly BeerController _beerController;
        private readonly IBeerService _beerService;

        public BeerControllerShould()
        {
            _beerService = new BeerService();
            _beerController = new BeerController(_beerService);
        }

        [Fact]
        public void Get_Ok()
        {
            //Arrange
                //En este caso no hay preparación de escenario
            //Act
            var result = _beerController.Get();

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_Quantity()
        {
            //No hay Arrange

            //Act
            var result = (OkObjectResult)_beerController.Get();
            var beers = Assert.IsType<List<Beer>>(result.Value);
            
            //Assert
            Assert.True(beers.Count > 0);
        }

        [Fact]
        public void GetById_Ok()
        {
            //Arrange
            int id = 1;

            //Act
            var result = _beerController.GetById(id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ValidateValidId()
        {
            //Arrange
            int id = 1;

            //Act
            var result = (OkObjectResult)_beerController.GetById(id);

            //Assert
            var beer = Assert.IsType<Beer>(result?.Value);
            Assert.True(beer != null);
            Assert.Equal(id, beer?.Id);
        }

        [Fact]
        public void InvalidateInvalidId()
        {
            //Arrange
            int id = 11;

            //Act
            var result = _beerController.GetById(id);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
