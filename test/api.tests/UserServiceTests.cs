using api.data;
using api.models;
using api.services;
using Moq;

namespace api.tests;

public class UserServiceTests
{
    [Fact]
    public async void Test_CreateUser_OK()
    {
        var mockRepo = new Mock<IRepository<User>>();
        mockRepo.Setup(repo => repo.Insert(It.IsAny<User>()));
        var svc = new UserService(mockRepo.Object);

        var result = await svc.CreateUser(new SignupUser { Email = "asd@asd.no", Password = "asd", ConfirmPassword = "asd" });

        mockRepo.Verify(r => r.Insert(It.IsAny<User>()), Times.Once);
        Assert.True(result);
    }

    [Fact]
    public async void Test_CreateUser_Fail()
    {
        var mockRepo = new Mock<IRepository<User>>();
        mockRepo.Setup(repo => repo.Insert(It.IsAny<User>())).ThrowsAsync(new Exception("FEIL"));
        var svc = new UserService(mockRepo.Object);

        Exception ex = await Assert.ThrowsAsync<Exception>(async () => await svc.CreateUser(new SignupUser { Email = "asd", Password = "asd", ConfirmPassword = "asd" }));
        Assert.Equal("FEIL", ex.Message);
    }

}