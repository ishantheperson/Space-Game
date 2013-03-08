using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Server {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("INFO: Starting server...");
            Server server = new Server(9186);
        }
    }
}
