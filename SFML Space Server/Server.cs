using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Xml;

namespace SpaceServer {
    class Server {
        private XmlDocument settings = new XmlDocument();
        private UdpClient server;
        private IPEndPoint endPoint;

        public Server(string settingPath) {
            settings.Load(settingPath);
            server = new UdpClient(new IPEndPoint(IPAddress.Any, int.Parse(settings["port"].Value)));

            Start();
        }

        private void Start() {
            Player player = new Player();

            server.BeginReceive(new AsyncCallback(Receive), player);
        }

        private void Receive(IAsyncResult result) {
            Player player = (Player)(result.AsyncState);
        }
    }

    struct Player {
        public string message;
    }
}
