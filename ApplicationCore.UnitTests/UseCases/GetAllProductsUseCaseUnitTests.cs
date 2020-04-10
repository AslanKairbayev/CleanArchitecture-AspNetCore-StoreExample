﻿using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Entities;
using ApplicationCore.Interactors;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationCore.UnitTests
{
    public class GetAllProductsUseCaseUnitTests
    {
        [Fact]
        public async void Can_Get_All_Products()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
              .Setup(m => m.ProductsWithCategories())
              .Returns(GetProductsWithCategories());

            var useCase = new GetProductsWithCategoriesUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetProductsWithCategoriesResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetProductsWithCategoriesResponse>()));

            var response = await useCase.Handle(new GetProductsWithCategoriesRequest(), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public async void Cant_Get_All_Products_When_Products_Are_Empty()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
              .Setup(m => m.ProductsWithCategories())
              .Returns(GetEmptyProductsWithCategories());

            var useCase = new GetProductsWithCategoriesUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetProductsWithCategoriesResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetProductsWithCategoriesResponse>()));

            var response = await useCase.Handle(new GetProductsWithCategoriesRequest(), mockOutputPort.Object);

            Assert.False(response);
        }

        public async Task<IEnumerable<Product>> GetProductsWithCategories()
        {
            var items = new List<Product>();

            items.Add(new Product() { Category = new Category() });

            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<Product>> GetEmptyProductsWithCategories()
        {
            var items = new List<Product>();

            return await Task.FromResult(items);
        }
    }
}
