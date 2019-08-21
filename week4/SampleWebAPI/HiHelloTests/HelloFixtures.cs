using Xunit;

namespace SampleWebAPI.Controllers.Tests
{
    public class HelloFixtures
    {
        [Fact]
        public void Hello_Controller_Checks()
        {
            HiHelloController HelloControllerObject = new HiHelloController();

            Assert.Equal("type in url hi or hello", HelloControllerObject.Get());
            Assert.Equal("error", HelloControllerObject.Get(""));
            Assert.Equal("hi", HelloControllerObject.Get("hello"));
        }
    }
}
