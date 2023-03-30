using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using UnitTestDemo.Controllers;
using UnitTestDemo.DataAccess;
using UnitTestDemo.DataAccess.Models;

namespace UnitTestDemo.Tests;

public class PeopleController_Tests
{
    [Fact]
    public async Task Get_ReturnsOkObjectResult_WithAListOfPeople()
    {
        //Arrange
        var count = 5;
        var people = A.CollectionOfDummy<Person>(count).AsEnumerable();
        var repository = A.Fake<IRepository>();
        A.CallTo(() => repository.GetAll<Person>()).Returns(Task.FromResult(people));

        var sut = new PeopleController(repository);

        //Act
        var result = await sut.Get();

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsAssignableFrom<IEnumerable<Person>>(okResult.Value);
        Assert.Equal(count, returnValue.Count());
    }

    [Fact]
    public async Task Post_Saves_Person()
    {
        //Arrange
        var dummyPerson = A.Dummy<Person>();
        var repository = A.Fake<IRepository>();
        A.CallTo(() => repository.Add(dummyPerson)).DoesNothing();

        var sut = new PeopleController(repository);

        //Act
        var result = await sut.Post(dummyPerson);

        //Assert
        Assert.True(result is CreatedAtActionResult);
    }
}