using System;
using System.Collections.Generic;
using System.Xml;

using SFML.Graphics;
using SMFL.Window;

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
                            case "Star":
                                objects.Add(new Starfield(2000, Color.White, new Vector2i(5000, 5000));
                                break;
                        }
                    }
                }
            }
        }
    }
}
