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

        public static bool Focused { get; set; }

        private static Sector sector;

        public static void Start() {
            Console.WriteLine("INFO: Game starting...");

            Loop();
        }

        public static void Loop() {
            gameWindow = new RenderWindow(new VideoMode(WindowWidth, WindowHeight), WindowTitle);
            gameWindow.Closed += (sender, args) => gameWindow.Close();
            gameWindow.SetFramerateLimit(60);

            Focused = true;
            gameWindow.GainedFocus += (sender, args) => Focused = true;
            gameWindow.LostFocus += (sender, args) => Focused = false;

            sector = new Sector("test.xml");

            while (gameWindow.IsOpen()) {
                gameWindow.DispatchEvents();
                gameWindow.Clear();

                // update (only if focused)
                if (Focused) {
                    sector.Update(gameWindow);
                }

                // draw
                sector.Draw(ref gameWindow);

                gameWindow.Display();
            }
        }
    }
}
