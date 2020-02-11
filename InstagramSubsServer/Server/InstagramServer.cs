using System.Net;
using System.Net.Sockets;

namespace InstagramSubsServer.Server
{
    public class InstagramServer
    {
        private TcpListener _server;

        public InstagramServer()
        {
            Connect();
        }

        private void Connect()
        {
            _server = new TcpListener(IPAddress.Any, port: 80);
            _server.Start();
        }

        private void ListenData()
        {

        }
    }
}