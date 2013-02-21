using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Ship {
        private string shipType;
        private int maxHealth;
        private int velocity;
        private int maxShield;
        private int shieldRegen;

        public Ship(string name) {
            using (XmlReader reader = XmlReader.Create("res/ship/" + name)) {
                while (reader.Read()) {
                    if (reader.IsStartElement()) {
                        switch (reader.Name) {
                            case "Type":
                                reader.Read(); shipType = reader.Value; break;
                            case "Health":
                                reader.Read(); maxHealth = int.Parse(reader.Value); break;
                            case "Velocity":
                                reader.Read(); velocity = int.Parse(reader.Value); break;
                            case "Shield":
                                reader.Read(); maxShield = int.Parse(reader.Value); break;
                            case "ShieldRegen":
                                reader.Read(); shieldRegen = int.Parse(reader.Value); break;
                        }
                    }
                }
            }
        }

        public void DisplayStats() {
            Console.WriteLine("Health: " + maxHealth);
        }
    }
}
