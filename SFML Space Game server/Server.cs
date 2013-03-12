using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SpaceGame.Server {
    class Server {
        public static void Start() {
            string welcome = "Welcome to the Server";
            byte[] data;

            try {
                IPEndPoint ip = new IPEndPoint(IPAddress.Any, 9186);
                UdpClient client = new UdpClient(ip);

                Console.WriteLine("Waiting for connections");

                IPEndPoint connection = new IPEndPoint(IPAddress.Any, 0);

                while (true) {
                    data = client.Receive(ref connection);
                    string message = Encoding.ASCII.GetString(data);
                    Console.WriteLine("INFO: Message from {0}: {1}", connection.ToString(), message);
                    // process server commands w/ message

                    // send message
                    Thread.Sleep(5000);
                    data = Encoding.ASCII.GetBytes(welcome);
                    client.Send(data, data.Length, connection);
                    connection = null; // recycle objects
                    Console.WriteLine("INFO: Message sent");
                }
            }
            catch (Exception e) {
                Console.WriteLine("ERROR: {0}", e);
            }
        }
    }
}