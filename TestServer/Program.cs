using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace TestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread server = new Thread(ServerThread)
            {
                IsBackground = true
            };
            server.Start();

            UdpClient client = new UdpClient();
            byte[] requeset = Encoding.ASCII.GetBytes("Test String");
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Any, 0);
            client.EnableBroadcast = true;
            client.Send(requeset, requeset.Length, new IPEndPoint(IPAddress.Broadcast, 8888));

            byte[] response = client.Receive(ref serverEP);
            string responseStr = Encoding.ASCII.GetString(response);

            Console.WriteLine("Recived {0} from {1}", responseStr, serverEP.Address.ToString());

            Console.ReadLine();
        }

        static void ServerThread()
        {
            UdpClient server = new UdpClient(8080);
            byte[] response = Encoding.ASCII.GetBytes("ROUTE OK.");

            while (true)
            {
                IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
                byte[] request = server.Receive(ref client);
                string requestStr = Encoding.ASCII.GetString(request);

                Console.WriteLine("Recived {0} from {1}, sending response", requestStr, client.Address.ToString());
                server.Send(response, response.Length, client);
            }
        }
    }
}