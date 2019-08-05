using System;
using System.Net;
using System.IO;
using System.Reflection;
using System.Threading;

namespace HTTPWebServerAppliation
{

    class Program
    {
        public static HttpListener listener = new HttpListener();
        public static string startUpPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        public static void Main(string[] args)
        {
            listener.Start();
            listener.Prefixes.Add("http://" + IPAddress.Loopback.ToString() + "/");
            Thread t = new Thread(new ThreadStart(clientListener));
            t.Start();
            Console.Write(">");
            while (true)
            {
                string s = Console.ReadLine();
                Console.Write(">");
            }
        }
        public static void clientListener()
        {
            while (true)
            {
                try
                {
                    HttpListenerContext request = listener.GetContext();
                    ThreadPool.QueueUserWorkItem(processRequest, request);
                }
                catch (Exception e) { Console.WriteLine(e.Message); Console.Write(">"); }
            }
        }
        public static void processRequest(object listenerContext)
        {
            try
            {
                var context = (HttpListenerContext)listenerContext;
                string filename = Path.GetFileName(context.Request.RawUrl);
                string path = Path.Combine(startUpPath, filename);
                byte[] msg;
                if (!File.Exists(path))
                {
                    Console.WriteLine("Client requested nonexistent file, sending error...");
                    Console.Write(">");
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    msg = File.ReadAllBytes(startUpPath + "\\webroot\\error.html");
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    msg = File.ReadAllBytes(path);
                }
                context.Response.ContentLength64 = msg.Length;
                using (Stream s = context.Response.OutputStream)
                    s.Write(msg, 0, msg.Length);
            }
            catch
            {
            }
        }
    }
}
