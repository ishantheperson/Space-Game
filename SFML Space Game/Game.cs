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

        private static Starfield starfield = new Starfield(50, Color.White);

        public static void Start() {
            Console.WriteLine("INFO: Game starting...");

            Loop();
        }

        public static void Loop() {
            gameWindow = new RenderWindow(new VideoMode(WindowWidth, WindowHeight), WindowTitle);
            gameWindow.Closed += (sender, args) => gameWindow.Close();

            while (gameWindow.IsOpen()) {
                gameWindow.DispatchEvents();
                gameWindow.Clear();

                starfield.Draw(ref gameWindow);

                gameWindow.Display();
            }
        }
    }
}
