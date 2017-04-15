using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BCS_Software
{
    internal sealed class NetworkManager : IDisposable 
    {
        private Socket _socket;
        private Socket _partner;
        private bool _isServer = false;

        public bool IsConnected
        {
            get
            {
                if (_isServer)
                    return _partner?.Connected ?? false;
                else
                    return _socket?.Connected ?? false;
            }
        }

        public NetworkManager(IPAddress serverIP, int port, bool isServer)
        {
            _isServer = isServer;
            if (_isServer)
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);

                _socket.Bind(endPoint);
                _socket.Listen(2);

                while (_partner == null)
                    _partner = _socket.Accept();
            }
            else
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPEndPoint endPoint = new IPEndPoint(serverIP, port);

                _socket.Connect(endPoint);
            }
        }

        public string GetMessage()
        {
            byte[] size = new byte[4];

            if (_isServer)
            {

                _partner.Receive(size);
                byte[] buffer = new byte[BitConverter.ToInt32(size, 0)];
                int msg = _partner.Receive(buffer);

                return Encoding.ASCII.GetString(buffer, 0, msg);
            }
            else
            {
                _socket.Receive(size);
                byte[] buffer = new byte[BitConverter.ToInt32(size, 0)];
                int msg = _socket.Receive(buffer);

                return Encoding.ASCII.GetString(buffer, 0, msg);
            }
        }

        public void SendMessage(string message)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);

            if (_isServer)
            {
                _partner.Send(BitConverter.GetBytes(buffer.Length));
                _partner.Send(buffer);
            }
            else
            {
                _socket.Send(BitConverter.GetBytes(buffer.Length));
                _socket.Send(buffer);
            }
        }

        public void CloseConnection()
        {
            if(_partner != null && _partner.Connected) _partner.Close();
            if(_socket != null && _socket.Connected) _socket.Close();
        }

        public void Dispose()
        {
            CloseConnection();

            if (_socket != null)
                _socket.Dispose();

            if (_partner != null)
                _partner.Dispose();
        }
    }
}
