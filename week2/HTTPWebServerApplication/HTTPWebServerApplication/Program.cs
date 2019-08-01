using System;
using System.IO;
using System.Net;
using System.Text;

namespace HTTPWebServerAppliation
{
    class Program
    {
        static void Main(String[] ar)
        {

            string url = "http://localhost:8080/index.html/";
            HttpListener listener = null;

            string strap = "";

            try
            {
                listener = new HttpListener();
                listener.Prefixes.Add(url);
                listener.Start();
                while (true)
                {
                    Console.WriteLine("Waiting..");
                    HttpListenerContext context = listener.GetContext();
                    string msg = "hello";


                    context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(msg);
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    using (Stream stream = context.Response.OutputStream)
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            writer.Write(msg);
                        }
                    }
                    Console.WriteLine("msg Sent");
                }

            }
            catch (WebException e)
            {
                Console.WriteLine(e.Status);
            }
        }

    }
}



