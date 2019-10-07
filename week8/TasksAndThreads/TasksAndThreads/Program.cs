using System;
using TasksAndThreads.NamespaceClassA;

namespace TasksAndThreads
{
    class Program
    {
        public static void Main()
        {
            string str;
            DemonstrationClass demoObj = new DemonstrationClass();

            demoObj.PrintUsingOut(out str);
            str = "random text changed using main";
            Console.WriteLine("from main:\t" + str);
            demoObj.PrintUsingRef(ref str);

            demoObj.TaskSample();

            demoObj.TestMethod();
        }
    }
}
