using api.controllers;
using api.models;
using api.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace api.tests;

public class SignupControllerTests
{
    [Fact]
    public async void Test_Signup_OKResult()
    {
        var mockRepo = new Mock<IUserService>();
        mockRepo.Setup(repo => repo.CreateUser(It.IsAny<SignupUser>()));
        var controller = new SignupController(mockRepo.Object);

        var result = await controller.PostActionAsync(new SignupUser { Email = "asd@asd.no", Password = "asd", ConfirmPassword = "asd" });

        Assert.IsType<OkResult>(result);

    }

    [Fact]
    public async void Test_Signup_BadInputResult()
    {
        var mockRepo = new Mock<IUserService>();
        mockRepo.Setup(repo => repo.CreateUser(It.IsAny<SignupUser>()));
        var controller = new SignupController(mockRepo.Object);

        var result = await controller.PostActionAsync(new SignupUser { Email = "asd@asd.no", Password = "asd", ConfirmPassword = "asd" });

        Assert.IsType<BadRequest>(result);
    }
}