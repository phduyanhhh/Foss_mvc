using G7.Foss.Models.TokenAuth;
using G7.Foss.Web.Controllers;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace G7.Foss.Web.Tests.Controllers;

public class HomeController_Tests : FossWebTestBase
{
    [Fact]
    public async Task Index_Test()
    {
        await AuthenticateAsync(null, new AuthenticateModel
        {
            UserNameOrEmailAddress = "admin",
            Password = "123qwe"
        });

        //Act
        var response = await GetResponseAsStringAsync(
            GetUrl<HomeController>(nameof(HomeController.Index))
        );

        //Assert
        response.ShouldNotBeNullOrEmpty();
    }
}