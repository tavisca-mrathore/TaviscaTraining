namespace RoverProblem
{
    public class West : IDirection
    {
        public void Move(ref Rover roverObj)
        {
            --roverObj.CurrX;
        }
    }
}
