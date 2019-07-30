using Xunit;

namespace RoverProblem.Tests
{
    public class RoverFixtures
    {
        [Fact]
        public void Constructor_and_Getter_Check()
        {
            Rover roverObj = new Rover(5, 7, "N");

            Assert.Equal(5, roverObj.CurrX);
            Assert.Equal(7, roverObj.CurrY);
            Assert.Equal("N", roverObj.FacingDirection);
        }

        [Fact]
        public void Setter_Check()
        {
            Rover roverObj = new Rover(0, 0, "N");
            roverObj.CurrX = 39;
            roverObj.CurrY = 67;
            roverObj.FacingDirection = "S";

            Assert.Equal(39, roverObj.CurrX);
            Assert.Equal(67, roverObj.CurrY);
            Assert.Equal("S", roverObj.FacingDirection);
        }

        [Fact]
        public void Move_Rover_Check()
        {
            Rover roverObj = new Rover(1, 2, "N");
            // roverObj.moveRover(roverObj);

            Assert.Equal(1, roverObj.CurrX);
            Assert.Equal(3, roverObj.CurrY);
        }
    }
}
