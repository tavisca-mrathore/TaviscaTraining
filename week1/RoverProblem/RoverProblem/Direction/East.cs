namespace RoverProblem
{
    public class East : IDirection
    {
        public void Move(ref Rover roverObj)
        {
            ++roverObj.CurrX;
        }
    }
}
