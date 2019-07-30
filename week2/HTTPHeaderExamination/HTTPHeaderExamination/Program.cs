using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HTTPHeaderExamination
{
    class HttpResponseParser
    {
        static Dictionary<string, string> Parse(string filename)
        {
            var temp = new Dictionary<string, string>();
            using (StreamReader file = new StreamReader(filename))
            {
                string ln = file.ReadLine();
                string[] s = ln.Split(new[] { ' ' });

                temp.Add("HTTP Method", s[0]);
                temp.Add("File returned", s[1]);
                temp.Add("HTTP Version", s[2]);

                while ((ln = file.ReadLine()) != null)
                {
                    if (ln.Contains(":"))
                    {
                        string[] sp = ln.Split(new[] { ':' }, 2);
                        temp.Add(sp[0], sp[1]);
                    }
                    else
                    {
                        break;
                    }
                }
                string data = file.ReadToEnd();
                temp.Add("Payload", data);
                file.Close();
            }

            return temp;
        }
        static void Main(string[] args)
        {
            var FILE_NAME = "header.txt";

            Parse(FILE_NAME).ToList().ForEach(
                entry => Console.WriteLine($"{entry.Key} : {entry.Value}")
            );

            Console.ReadLine();
        }
    }
}
