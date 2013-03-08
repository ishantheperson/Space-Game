using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SpaceGame.Server {
    class Server {
        IPEndPoint address;

        Player[] players;

        public Server(int port, int capacity) {
            players = new Player[capacity];
        }

        public void Listen() {
            for (int i = 0; i < players.Length; i++) {
                players[i] = new Player(new IPEndPoint(IPAddress.Any, 0));
            }
        }
    }
}