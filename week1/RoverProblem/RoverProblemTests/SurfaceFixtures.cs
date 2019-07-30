using Xunit;

namespace RoverProblem.Tests
{
    public class SurfaceFixtures
    {
        [Fact]
        public void Constructor_and_Getter_Check()
        {
            Surface surfaceObj = new Surface(0, 0);
            Assert.Equal(0, surfaceObj.LimitX);
            Assert.Equal(0, surfaceObj.LimitY);
        }
        [Fact]
        public void Setter_Check()
        {
            Surface surfaceObj = new Surface(39, 67);
            surfaceObj.LimitX = 59;
            surfaceObj.LimitY = 87;
            Assert.Equal(59, surfaceObj.LimitX);
            Assert.Equal(87, surfaceObj.LimitY);
        }
    }
}
