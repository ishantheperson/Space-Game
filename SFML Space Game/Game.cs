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

        private static bool splash = true;
        //private static Fadable splashScreen;

        private static Sector sector;

        public static View View { get { return gameWindow.GetView(); } set { gameWindow.SetView(value); } }

        public static void Start() {
            Console.WriteLine("INFO: Game starting...");
            
            Loop();
        }

        private static void Loop() {
            gameWindow = new RenderWindow(new VideoMode(WindowWidth, WindowHeight), WindowTitle);
            gameWindow.Closed += (sender, args) => gameWindow.Close();
            gameWindow.SetFramerateLimit(60);

            Focused = true;
            gameWindow.GainedFocus += (sender, args) => Focused = true;
            gameWindow.LostFocus += (sender, args) => Focused = false;

            sector = new Sector("test.xml");
            Ship ship = new Ship();
            ship.Read("ShipOne.xml");
            ship.DisplayStats();
            //splashScreen = new Fadable("ui/splash.png", new Vector2f());
            //splashScreen.Completed += (sender, args) => splash = false;

            while (gameWindow.IsOpen()) {
                gameWindow.DispatchEvents();
                gameWindow.Clear();

                /*if (!splash) {
                    // update (only if focused)
                    if (Focused) {
                        sector.Update(gameWindow);
                    }

                    // draw
                    sector.Draw(ref gameWindow);
                }
                else {
                    splashScreen.Update(gameWindow);
                    splashScreen.Draw(ref gameWindow);
                }*/
                gameWindow.Display();
            }
        }
    }
}
