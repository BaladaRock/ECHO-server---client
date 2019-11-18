using System;
using System.Net;
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
            var newClient = new Client("localHost", 10000);
            TcpClient client = newClient.TcpClient;

            byte[] sentData = Encoding.ASCII.GetBytes(Console.ReadLine());

            NetworkStream stream = newClient.TcpClient.GetStream();

            stream.Write(sentData);

            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = stream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));

            stream.Close();
            client.Close();

            Console.Read();
        }
    }
}