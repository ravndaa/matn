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
        mockRepo.Setup(repo => repo.CreateUser(It.IsAny<SignupUser>())).ReturnsAsync(true);
        var controller = new SignupController(mockRepo.Object);

        var result = await controller.PostActionAsync(new SignupUser { Email = "asd@asd.no", Password = "asd", ConfirmPassword = "asd" });

        Assert.IsType<NoContentResult>(result);

    }

    [Fact]
    public async void Test_Signup_CreateUserFailsResult()
    {
        var mockRepo = new Mock<IUserService>();
        mockRepo.Setup(repo => repo.CreateUser(It.IsAny<SignupUser>())).ReturnsAsync(false);
        var controller = new SignupController(mockRepo.Object);

        var result = await controller.PostActionAsync(new SignupUser { Email = "asd@asd.no", Password = "asd", ConfirmPassword = "asd" });

        Assert.IsType<BadRequestResult>(result);

    }


    public static IEnumerable<object[]> FailedData =>
        new List<object[]>
        {
            new object[] { "asd@asd.no","asd","" },
            new object[] { "asd@asd.no","","asd" },
            new object[] { "","","" },
            new object[] { "","asd","asd" },
            new object[] { "asd@asd.no","asd","ads1" },
            new object[] { "asd@asd.no","","" },
        };

    [Theory]
    [MemberData(nameof(FailedData))]
    public async void Test_Signup_BadInputResult(string email, string password, string confirmpassword)
    {
        var mockRepo = new Mock<IUserService>();
        mockRepo.Setup(repo => repo.CreateUser(It.IsAny<SignupUser>())).ReturnsAsync(true);
        var controller = new SignupController(mockRepo.Object);

        var result = await controller.PostActionAsync(new SignupUser { Email = email, Password = password, ConfirmPassword = confirmpassword });

        Assert.IsType<BadRequestResult>(result);
    }
}