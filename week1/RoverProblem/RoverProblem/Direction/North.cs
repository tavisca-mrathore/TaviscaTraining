namespace RoverProblem
{
    public class North : IDirection
    {
        public void Move(ref Rover roverObj)
        {
            ++roverObj.CurrY;
        }
    }
}
