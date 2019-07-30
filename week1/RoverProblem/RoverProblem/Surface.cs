namespace RoverProblem
{
    public class Surface
    {
        private int __limitX, __limitY;

        public Surface(int limX, int limY)
        {
            __limitX = limX;
            __limitY = limY;
        }

        public int LimitX
        {
            get => __limitX;
            set => __limitX = value;
        }

        public int LimitY
        {
            get => __limitY;
            set => __limitY = value;
        }
    }
}
