using System;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Game {
        private static RenderWindow gameWindow;

        public const int WindowWidth = 800;
        public const int WindowHeight = 600;
        public const string WindowTitle = "The Amazing C# Space Game";

        public static void Start() {
            Console.WriteLine("INFO: Game starting...");

            Loop();
        }

        public static void Loop() {
            Event e;

            gameWindow = new RenderWindow(new VideoMode(WindowWidth, WindowHeight), WindowTitle);

            while (gameWindow.IsOpen()) {
                gameWindow.DispatchEvents();
                gameWindow.Clear();

                gameWindow.Display();
            }
        }
    }
}
