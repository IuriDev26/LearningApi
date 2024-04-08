using FirstApi.Controllers;
using FirstApi.DTOs.Entities;
using FirstApixUnitTestes.ProdutosControllerUnitTest;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApixUnitTestes.ProdutosControllerUnitTest {
    public class GetUnitTests : IClassFixture<ProdutoUnitTesteController> {

        private readonly ProdutosController _controller;

        public GetUnitTests(ProdutoUnitTesteController controller) {
            _controller = new ProdutosController(controller.Uof, controller.Mapper);
        }

        [Fact]
        public async Task GetAll_Return_ListOfProdutoDTO() {

            //Arrange

            //Act
            var data = _controller.Get();

            //Assert
            data.Result.Should().BeOfType<ActionResult<IEnumerable<ProdutoDTO>>>();

        }


    }
}
