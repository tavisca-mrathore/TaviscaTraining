namespace RoverProblem
{
    public class Rover
    {
        private int __currX, __currY;
        private string __facingDirection;
        private static Surface surfaceMatrix;
        private static int TOTAL_DIRECTIONS = DirectionEnum.GetNames(typeof(DirectionEnum)).Length;
        // private static Dictionary<int, Func<>> TurnDict = new Dictionary<int, Func<>>();

        public Rover(int currX, int currY, string currDir)
        {
            __currX = currX;
            __currY = currY;
            __facingDirection = currDir;
        }

        public int CurrX
        {
            get => __currX;
            set => __currX = value;
        }

        public int CurrY
        {
            get => __currY;
            set => __currY = value;
        }

        public string FacingDirection
        {
            get => __facingDirection;
            set => __facingDirection = value;
        }

        public void TurnRover(int margin)
        {
            // TurnDict[(DirectionEnum[FacingDirection] + margin) % TOTAL_DIRECTIONS];
        }

        public void SetFinalPosition(string movementString, Rover roverObj)
        {
            foreach (char turnDirection in movementString)
            {
                if (turnDirection == 'L')
                {
                    TurnRover(-1);
                }
                else if (turnDirection == 'R')
                {
                    TurnRover(1);
                }
                else
                {
                    // move rover
                }
            }
        }
    }
}
