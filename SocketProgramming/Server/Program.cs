using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace C_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[1];
            TcpListener server = new TcpListener(ip, 8080);
            TcpClient client = default(TcpClient);

            try 
            {
                server.Start();
                Console.WriteLine("Server Started...");
                Console.Read();

            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }


            while(true)
            {
                client = server.AcceptTcpClient();

                if (client.Connected)
                {
                    Console.WriteLine("CLIENT CONNECTED");
                }

                byte[] recievedBuffer = new byte[100];

                NetworkStream stream = client.GetStream();

                stream.Read(recievedBuffer, 0, recievedBuffer.Length);

                string msg = Encoding.ASCII.GetString(recievedBuffer, 0, recievedBuffer.Length);

                Console.WriteLine(msg);

            }

        }
    }
}
