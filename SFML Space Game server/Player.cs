using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace SpaceGame.Server {
    class Player {
        IPEndPoint connection;
        Thread listenThread;
        UdpClient server;

        public bool Connected {
            get {
                if (connection.Address.ToString() != null) {
                    return true;
                }
                return false;
            }
        }

        public Player(IPEndPoint ip) {
            server = new UdpClient(ip);
            connection = new IPEndPoint(IPAddress.Any, 0);
            listenThread = new Thread(Listen, 0);
            listenThread.Start();
        }

        private void Listen() {
            while (true) {
                byte[] data = new byte[1024];
                data = server.Receive(ref connection);

                Console.WriteLine("INFO: Data received from {0} \n {1} \n", connection.Address.ToString(), Encoding.ASCII.GetString(data));
            }
        }

        public override string ToString() {
            return "Player " + connection.ToString();
        }
    }
}
