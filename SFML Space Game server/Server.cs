using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SpaceGame.Server {
    class Server {
        UdpClient client;
        List<IPEndPoint> connections;
        byte[] data = new byte[1024];

        public Server(int port) {
            connections.Add(new IPEndPoint(IPAddress.Any, port));
        }

        private void Listen() {
            
        }
    }
}
