using System;
using System.Collections.Generic;
using System.Xml;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Sector {
        private FloatRect top, right, left, bottom;

        private Vector2f offset = new Vector2f();
        private Vector2i size = new Vector2i();

        private Dictionary<string, DrawableGameObject> objects = new Dictionary<string, DrawableGameObject>();

        /// <summary>
        /// Creates a new sector, and adds a player
        /// </summary>
        /// <param name="name">Level name, located in res/level/</param>
        public Sector(string name) {
            #region Parse level file
            using (XmlReader reader = XmlReader.Create(@"res/level/" + name)) {
                while (reader.Read()) {
                    if (reader.IsStartElement()) {
                        switch (reader.Name) {
                            case "Size":
                                Console.WriteLine("INFO: Size component started");
                                reader.Read();
                                while (true) {
                                    if (reader.Name == "Size" && reader.NodeType == XmlNodeType.EndElement) break;
                                    reader.Read();
                                    if (reader.IsStartElement()) {
                                        switch (reader.Name) {
                                            case "X":
                                                Console.WriteLine("INFO: X component found");
                                                reader.Read();
                                                size.X = int.Parse(reader.Value); break;

                                            case "Y":
                                                Console.WriteLine("INFO: Y component found");
                                                reader.Read();
                                                size.Y = int.Parse(reader.Value); break;
                                        }
                                    }
                                }
                                Console.WriteLine("INFO: Size component ended");
                                break;

                            case "Starfield": // starfield exists
                                int count = 0;
                                Color color = new Color();

                                reader.Read();
                                while (true) {
                                    if (reader.Name == "Starfield" && reader.NodeType == XmlNodeType.EndElement) break;
                                    reader.Read();

                                    switch (reader.Name) {
                                        case "Count":
                                            if (count == 0) {
                                                Console.WriteLine("INFO: Started Count element");
                                                reader.Read();
                                                count = int.Parse(reader.Value);
                                                Console.WriteLine("INFO: Ended Count element");
                                            }
                                            break;

                                        case "Color":
                                            Console.WriteLine("INFO: Started Color element");
                                            reader.Read();
                                            while (true) {
                                                color.A = 255;
                                                if (reader.Name == "Color" && reader.NodeType == XmlNodeType.EndElement) break;
                                                reader.Read();
                                                if (reader.IsStartElement()) {
                                                    switch (reader.Name) {
                                                        case "R":
                                                            Console.WriteLine("INFO: Red component found");
                                                            reader.Read();
                                                            color.R = byte.Parse(reader.Value); break;

                                                        case "G":
                                                            Console.WriteLine("INFO: Green component found");
                                                            reader.Read();
                                                            color.G = byte.Parse(reader.Value); break;

                                                        case "B":
                                                            Console.WriteLine("INFO: Blue component found");
                                                            reader.Read();
                                                            color.B = byte.Parse(reader.Value); break;
                                                    }
                                                }
                                            }
                                            Console.WriteLine("INFO: Ended Color element");
                                            break;
                                    }
                                }


                                objects.Add("starfield", new Starfield(count, color, size));
                                break;
                        }
                    }
                }
            }
            #endregion

            #region Rectangles
            top = new FloatRect(0, 0, Game.WindowWidth, 200);
            right = new FloatRect(Game.WindowWidth - 200, 0, 200, Game.WindowHeight);
            left = new FloatRect(0, 0, 200, Game.WindowHeight);
            bottom = new FloatRect(0, Game.WindowHeight - 200, Game.WindowWidth, 200);
            #endregion

            objects.Add("player", new Player());

        }

        /// <summary>
        /// Updates all objects in this Sector
        /// </summary>
        /// <param name="window">Window to pass</param>
        public void Update(RenderWindow window) {
            if (((Player)objects["player"]).Bounds.Intersects(top) && offset.Y > 0) {
                // move up
            }

            if (((Player)objects["player"]).Bounds.Intersects(left) && offset.X > 0) {
                // move left
            }

            if (((Player)objects["player"]).Bounds.Intersects(right) && offset.X - (Game.View.Center.X - 300) < size.X) {
                offset.X += 5;
                Game.View.Move(offset);
                Console.WriteLine("right hit");
            }

            if (((Player)objects["player"]).sprite.GetGlobalBounds().Intersects(bottom) && offset.Y < size.Y) {
                Game.View.Move(new Vector2f(0, 4));

            }

            foreach (KeyValuePair<string, DrawableGameObject> drawable in objects) {
                drawable.Value.Update(window);
            }
        }

        /// <summary>
        /// Draws all objects in this Sector
        /// </summary>
        /// <param name="window">Window to draw to</param>
        public void Draw(ref RenderWindow window) {
            foreach (KeyValuePair<string, DrawableGameObject> drawable in objects) {
                drawable.Value.Draw(ref window);
            }
        }
    }
}
