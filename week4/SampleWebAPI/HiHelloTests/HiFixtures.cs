using Xunit;

namespace SampleWebAPI.Controllers.Tests
{
    public class HiFixtures
    {
        [Fact]
        public void Hi_Controller_Checks()
        {
            HiHelloController HiControllerObject = new HiHelloController();

            Assert.Equal("type in url hi or hello", HiControllerObject.Get());
            Assert.Equal("error", HiControllerObject.Get(""));
            Assert.Equal("hello", HiControllerObject.Get("hi"));
        }
    }
}
