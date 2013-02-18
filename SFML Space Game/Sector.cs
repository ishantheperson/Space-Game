using System;
using System.Collections.Generic;
using System.Xml;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Sector {
        private IntRect top, right, left, bottom;
        public View sectorView;

        private List<DrawableGameObject> objects;

        public Sector(string name) {
            using (XmlReader reader = XmlReader.Create(@"res/level/" + name)) {
                while (reader.Read()) {
                    if (reader.IsStartElement()) {
                        switch (reader.Name) {
                            case "Starfield": // starfield exists
                                int count;
                                Color color;
                                Vector2i size;

                                while (reader.Value != "/Starfield") {
                                    if (reader.IsStartElement()) {
                                        switch (reader.Name) {
                                            case "Count":
                                                count = int.Parse(reader.Value);
                                                break;

                                            case "Color":

                                        }
                                    }
                                }
                                
                                break;
                        }
                    }
                }
            }
        }
    }
}
