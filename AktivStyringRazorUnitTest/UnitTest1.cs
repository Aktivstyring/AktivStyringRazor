using Microsoft.VisualStudio.TestTools.UnitTesting;
using AktivStyringRazor.Services;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using AktivStyringRazor.Models;

namespace AktivStyringRazorUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        IConfiguration Configuration { get; }
        public UnitTest1(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [TestMethod]
        public async void TestMethod1()
        {
            //Arrange
            bool expected=true;
            IPersonerService personTestService = new PersonService(Configuration);
            Personer eksempelPerson = new Personer(1, "Bjarke Cooper", "yahoo@gmail.com","+4231312312", "rådmandsvej 2", 30);

            //Act
            bool result = await personTestService.AddPersonerAsync(eksempelPerson);

            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}
