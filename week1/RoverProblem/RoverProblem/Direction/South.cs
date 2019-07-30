namespace RoverProblem
{
    public class South : IDirection
    {
        public void Move(ref Rover roverObj)
        {
            --roverObj.CurrY;
        }
    }
}
