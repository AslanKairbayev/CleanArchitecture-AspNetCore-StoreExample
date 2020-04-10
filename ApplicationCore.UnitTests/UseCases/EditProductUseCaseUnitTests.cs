﻿using ApplicationCore.Dto.RepositoryResponses.ProductRepository;
using ApplicationCore.Dto.UseCaseRequests;
using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationCore.UnitTests
{
    public class EditProductUseCaseUnitTests
    {
        [Fact]
        public async void Can_Edit_Product()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
              .Setup(m => m.Update(It.IsAny<Product>()))
              .Returns(Task.FromResult(new UpdateProductResponse(true)));

            mockProductRepository
              .Setup(m => m.GetProductById(It.IsAny<int>()))
              .Returns(Task.FromResult(new Product()));

            var useCase = new EditProductUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<EditProductResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<EditProductResponse>()));

            var response = await useCase.Handle(new EditProductRequest(It.IsAny<int>(),"name", "description", It.IsAny<decimal>(), It.IsAny<int>()), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public async void Cant_Edit_Product_When_Product_Not_Found()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
              .Setup(m => m.Update(It.IsAny<Product>()))
              .Returns(Task.FromResult(new UpdateProductResponse(true)));

            mockProductRepository
              .Setup(m => m.GetProductById(It.IsAny<int>()))
              .Returns(Task.FromResult(It.IsAny<Product>()));

            var useCase = new EditProductUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<EditProductResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<EditProductResponse>()));

            var response = await useCase.Handle(new EditProductRequest(It.IsAny<int>(), "name", "description", It.IsAny<decimal>(), It.IsAny<int>()), mockOutputPort.Object);

            Assert.False(response);
        }

        [Fact]
        public async void Cant_Edit_Product_When_Request_Is_Invalid()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
              .Setup(m => m.Update(It.IsAny<Product>()))
              .Returns(Task.FromResult(new UpdateProductResponse(true)));

            mockProductRepository
              .Setup(m => m.GetProductById(It.IsAny<int>()))
              .Returns(Task.FromResult(new Product()));

            var useCase = new EditProductUseCase(mockProductRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<EditProductResponse>>();

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<EditProductResponse>()));

            var response = await useCase.Handle(new EditProductRequest(It.IsAny<int>(), "", "description", It.IsAny<decimal>(), It.IsAny<int>()), mockOutputPort.Object);

            Assert.False(response);
        }
    }
}
