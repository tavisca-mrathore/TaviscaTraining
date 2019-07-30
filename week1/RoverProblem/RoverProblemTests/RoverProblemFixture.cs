using Xunit;

namespace RoverProblem.Tests
{
    public class RoverProblemFixture
    {
        [Fact]
        public void Final_Position_Check_1()
        {
            Surface surfaceObj = new Surface(5, 5);
            Rover roverObj = new Rover(1, 2, "N");
            roverObj.SetFinalPosition("LMLMLMLMM", roverObj);

            Assert.Equal(1, roverObj.CurrX);
            Assert.Equal(3, roverObj.CurrY);
            Assert.Equal("N", roverObj.FacingDirection);
        }

        [Fact]
        public void Final_Position_Check_2()
        {
            Surface surfaceObj = new Surface(5, 5);
            Rover roverObj = new Rover(3, 3, "E");
            roverObj.SetFinalPosition("MMRMMRMRRM", roverObj);

            Assert.Equal(5, roverObj.CurrX);
            Assert.Equal(1, roverObj.CurrY);
            Assert.Equal("E", roverObj.FacingDirection);
        }
    }
}
