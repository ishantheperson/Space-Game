using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SpaceServer {
    class Server {
        struct Player {
            int x, y;
            string name;
        }

        List<Player> players = new List<Player>();

        const int port = 9000;

        UdpClient server = new UdpClient(port);
        IPEndPoint address = new IPEndPoint(IPAddress.Any, 0);

        public void Listen() {
            while (true) {
                byte[] data = server.Receive(ref address);
                string command = ASCIIEncoding.ASCII.GetString(data);

                Console.WriteLine("Message received: " + command);
            }
        }
    }
}
