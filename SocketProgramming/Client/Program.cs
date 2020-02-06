using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to start connection");
            Console.Read();

            string serverIP = "localhost";
            int port = 8080;

            string msg = "Hey there pardner!";


            TcpClient client = new TcpClient(serverIP, port);

            int byteCount = Encoding.ASCII.GetByteCount(msg);

            byte[] sendData = new byte[byteCount];

            sendData = Encoding.ASCII.GetBytes(msg);

            NetworkStream stream = client.GetStream();

            stream.Write(sendData, 0, sendData.Length);

            stream.Close();
            client.Close();

        }
    }
}
