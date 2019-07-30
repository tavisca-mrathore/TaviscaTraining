using System;
using System.Net.Sockets;
using System.Text;

namespace SocketClient
{
    class Program
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "172.16.5.137";
        static void Main(string[] args)
        {
            //---data to send to the server---
            string textToSend;
            byte[] bytesToSend;

            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            Console.WriteLine("Client Started");

            while (true)
            {
                textToSend = Console.ReadLine();
                bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

                //---send the text---
                Console.WriteLine("Sending : " + textToSend);
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                //---read back the text---
                byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                nwStream.Flush();
                Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            }
            client.Close();
        }
    }
}
