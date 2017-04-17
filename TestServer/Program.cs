using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace TestServer
{
    internal static class Constants
    {
        internal static readonly byte[] NameIsTaken = { 0x01 };
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
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
    }

    internal class Server
    {
        private List<Client> _clients = new List<Client>();
        private Socket _server;

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }
        private int _port;

        private Thread _acceptor, _worker;

        public Server(int port)
        {
            _port = port;

            _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _server.Bind(new IPEndPoint(IPAddress.Any, _port));
        }

        public void Start()
        {
            _acceptor = new Thread(AcceptClients)
            {
                IsBackground = true
            };
            _acceptor.Start();

            _worker = new Thread(WorkerThread)
            {
                IsBackground = true
            };
            _worker.Start();
        }

        public void Stop()
        {
            _acceptor.Abort();
            _worker.Abort();
        }

        private void AcceptClients()
        {
            while (true)
            {
                Socket client = _server.Accept();

                byte[] buffer = new byte[4];
                int msg = client.Receive(buffer);

                int length = BitConverter.ToInt32(buffer, 0);

                buffer = new byte[length];
                msg = client.Receive(buffer);

                string name = Encoding.ASCII.GetString(buffer);

                if (_clients.Exists(c => c.Name == name))
                {
                    client.Send(BitConverter.GetBytes(-1));
                    client.Send(Constants.NameIsTaken);

                    client.Disconnect(false);
                }
                else
                {
                    Client newClient = new Client
                    {
                        Name = name,
                        Socket = client
                    };

                    _clients.Add(newClient);

                    Console.WriteLine("{0} connected.", newClient.Name);
                }
            }
        }

        private void SendToAll(byte[] buffer)
        {
            foreach (Client client in _clients)
            {
                if (client.Socket.Connected)
                {
                    client.Socket.Send(buffer);
               }
            }
        }

        private void WorkerThread()
        {
            while (true)
            {
                List<Client> disconnected = new List<Client>();

                foreach (Client client in _clients)
                {
                    if (!client.Socket.Connected)
                    {
                        disconnected.Add(client);
                        continue;
                    }

                    if (!client.Socket.Connected) disconnected.Add(client);

                    if (client.Socket.Available > 0)
                    {
                        byte[] buffer = new byte[4];
                        int msg = client.Socket.Receive(buffer);

                        int length = BitConverter.ToInt32(buffer, 0);

                        if (length > 0)
                        {
                            buffer = new byte[length];
                            msg = client.Socket.Receive(buffer);
                            string message = Encoding.ASCII.GetString(buffer, 0, length);

                            Console.WriteLine("{0}: {1}", client.Name, message);

                            SendToAll(buffer);
                        }
                        else
                        {
                            buffer = new byte[1];
                            msg = client.Socket.Receive(buffer);
                            byte code = buffer[0];

                            switch (code)
                            {
                                // parse the codes
                                default:
                                    break;
                            }
                        }
                    }
                }

                if (disconnected.Any())
                {
                    foreach (Client client in disconnected)
                    {
                        Console.WriteLine("{0} disconnected.", client.Name);
                        _clients.Remove(client);
                    }
                }

                Thread.Sleep(10);
            }
        }
    }

    internal class Client
    {
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        private string _name;

        public Socket Socket
        {
            get { return _socket; }
            set { _socket = value; }
        }
        private Socket _socket;
    }
}