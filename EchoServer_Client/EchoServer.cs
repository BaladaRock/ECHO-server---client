using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoServer
{
    internal class EchoServer
    {
        public EchoServer(IPAddress ip)
        {
            Server = new TcpListener(ip, 10000);
            Client = default(TcpClient);
        }

        public TcpListener Server { get; set; }
        public TcpClient Client { get; set; }

        internal static void Main(string[] args)
        {
            const byte maxValue = byte.MaxValue;

            var EchoServer = new EchoServer(Dns.GetHostEntry("localHost").AddressList[0]);
            TcpListener server = EchoServer.Server;
            TcpClient client = EchoServer.Client;
            server.Start();

            while (true)
            {
                byte[] buffer = new byte[maxValue];
                NetworkStream dataStream = server.AcceptTcpClient().GetStream();

                dataStream.Read(buffer, 0, maxValue);

                Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, maxValue));
                Console.ReadKey();
            }
        }
    }
}
