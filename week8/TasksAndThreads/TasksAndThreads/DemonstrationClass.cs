using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

class CustomData
{
    public long CreationTime;
    public int Name;
    public int ThreadNum;
}

namespace TasksAndThreads.NamespaceClassA
{
    public class DemonstrationClass
    {
        public void PrintUsingOut(out string obj)
        {
            obj = "random text initialized using out";
            Console.WriteLine("from out function:\t" + obj);
        }

        public void PrintUsingRef(ref string obj)
        {
            obj = "random text changed using ref function";
            Console.WriteLine("from ref function:\t" + obj);
        }

        public void TaskSample()
        {
            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) =>
                {
                    CustomData data = obj as CustomData;
                    if (data == null)
                        return;

                    data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                },
                new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks });
            }
            Task.WaitAll(taskArray);
            foreach (var task in taskArray)
            {
                var data = task.AsyncState as CustomData;
                if (data != null)
                    Console.WriteLine("Task #{0} created at {1}, ran on thread #{2}.",
                                      data.Name, data.CreationTime, data.ThreadNum);
            }
        }

        List<int> myList = new List<int>();
        public void TestMethod()
        {
            myList.Add(100);
            myList.Add(50);
            myList.Add(10);

            ChangeList(myList);
            foreach (int i in myList)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine();
        }
        private void ChangeList(List<int> myList1)
        {
            myList1.Sort();
            List<int> myList2 = new List<int>();
            myList2.Add(3);
            myList2.Add(4);
            myList1 = myList2;
        }

    }
}
