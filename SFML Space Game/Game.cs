using System;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Game {
        #region Game State
        public enum GameStates {
            Splash,
            Menu,
            Game
        }

        private static GameStates gameState = GameStates.Menu; // change to Game to test game
        public static GameStates GameState { get { return gameState; } set { gameState = value; } }
        #endregion

        #region Window
        private static RenderWindow gameWindow;

        public const int WindowWidth = 800;
        public const int WindowHeight = 600;
        public const string WindowTitle = "The Amazing C# Space Game";
        #endregion

        private static Menu menu = new Menu();

        public static bool Focused { get; set; }

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
            Ship ship = new Ship("test.xml");

            ship.DisplayStats();
            //splashScreen = new Fadable("ui/splash.png", new Vector2f());
            //splashScreen.Completed += (sender, args) => splash = false;

            while (gameWindow.IsOpen()) {
                Console.WriteLine("INFO: Dispatching events..");
                gameWindow.DispatchEvents();
                Console.WriteLine("INFO: Dispatched");
                gameWindow.Clear();

                switch (GameState) {
                    case GameStates.Menu:
                        // game menu
                        if (Focused) menu.Update(gameWindow);
                        menu.Draw(ref gameWindow);
                        Console.WriteLine("INFO: GameState = Menu");
                        break;

                    case GameStates.Game:
                        Console.WriteLine("INFO: GameState = Game");
                        // update (only if focused)
                        if (Focused) sector.Update(gameWindow);
                        // draw
                        sector.Draw(ref gameWindow);
                        break;
                }

                gameWindow.Display();
            }
        }
    }
}
