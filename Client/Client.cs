using System;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Client
    {
        public Client(string serverIP, int dataPort)
        {
            TcpClient = new TcpClient(serverIP, dataPort);
        }

        public TcpClient TcpClient { get; set; }

        internal static void Main(string[] args)
        {
            var client = new Client("localHost", 10000);

            NetworkStream stream = client.TcpClient.GetStream();
            stream.Write(Encoding.ASCII.GetBytes(Console.ReadLine()));


            stream.Close();
            client.TcpClient.Close();
        }
    }
}