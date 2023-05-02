using AdminService.BusinessLogicLayer.DTO;
using AdminService.Controllers;
using AdminService.DataAccessLayer.Entities;
using AdminService.DataAccessLayer.Repository.Impl;
using AdminService.DataAccessLayer.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using Xunit;

namespace WebApi.XunitTest
{
    public class TestToDoAuthController
    {

        [Fact]
        public async Task LoginPost_ShouldReturn200Status()
        {
            ///Arrange
            NewUserRequestModel newUserModel = new NewUserRequestModel() { Username="admin1", Password="12345678" };
            User model = new User();
            var todoService = new Mock<IRepositoryWrapper>();
            todoService.Setup(_ => _.UserRepository.AddAsync(model)).ReturnsAsync(model);
            var sut = new UsersController(null, todoService.Object);

            ///Act
            var result = await sut.AddUser(newUserModel) as ObjectResult;

            ///Assert
            Assert.Equal(result.StatusCode, 200);
        }
    }
}