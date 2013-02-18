using System;
using System.Collections.Generic;
using System.Xml;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Sector {
        private IntRect top, right, left, bottom;
        public View sectorView;

        private List<DrawableGameObject> objects = new List<DrawableGameObject>();

        /// <summary>
        /// Creates a new sector, and adds a player
        /// </summary>
        /// <param name="name">Level name, located in res/level/</param>
        public Sector(string name) {
            objects.Add(new Player());
            using (XmlReader reader = XmlReader.Create(@"res/level/" + name)) {
                while (reader.Read()) {
                    if (reader.IsStartElement()) {
                        switch (reader.Name) {
                            case "Starfield": // starfield exists
                                int count = 0;
                                Color color = new Color();
                                Vector2i size = new Vector2i();

                                reader.Read();
                                while (reader.Name != "Starfield" && reader.NodeType != XmlNodeType.EndElement) {
                                    reader.Read();
                                    if (reader.IsStartElement()) {
                                        switch (reader.Name) {
                                            case "Count":
                                                Console.WriteLine("INFO: Started Count element");
                                                reader.Read();
                                                count = int.Parse(reader.Value);
                                                Console.WriteLine("INFO: Ended Count element");
                                                break;

                                            case "Color":
                                                Console.WriteLine("INFO: Started Color element");
                                                reader.Read();
                                                while (reader.Name != "Color" && reader.NodeType != XmlNodeType.EndElement) {
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

                                            case "Size":
                                                Console.WriteLine("INFO: Size component started");
                                                reader.Read();
                                                while (reader.Name != "Size" && reader.NodeType != XmlNodeType.EndElement) {
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
                                        }
                                    }
                                }

                                objects.Add(new Starfield(count, color, size));

                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Updates all objects in this Sector
        /// </summary>
        /// <param name="window">Window to pass</param>
        public void Update(RenderWindow window) {
            foreach (DrawableGameObject drawable in objects) {
                drawable.Update(window);
            }
        }

        /// <summary>
        /// Draws all objects in this Sector
        /// </summary>
        /// <param name="window">Window to draw to</param>
        public void Draw(ref RenderWindow window) {
            foreach (DrawableGameObject drawable in objects) {
                drawable.Draw(ref window);
            }
        }
    }
}
