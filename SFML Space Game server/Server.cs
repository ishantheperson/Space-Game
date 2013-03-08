using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SpaceGame.Server {
    class Server {
        UdpClient client;
        IPEndPoint address;

        IPEndPoint sender;

        byte[] data = new byte[1024];

        public Server(int port) {
            address = new IPEndPoint(IPAddress.Any, port);
            client = new UdpClient(address);

            sender = new IPEndPoint(IPAddress.Any, 0);

            data = client.Receive(ref sender);
            Console.WriteLine("Message Received from: " + sender.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
        }

        private void Listen() {
            
        }
    }
}
