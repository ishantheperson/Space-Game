using System;
using System.Xml;
using System.Collections.Generic;

namespace SpaceGame {
    public class Ship {
        private string name = "default";
        private int maxHealth = 100;
        private int velocity;
        private int maxShield;
        private int shieldRegen;

        public int ShieldRegen { get { return shieldRegen; } set { shieldRegen = value; } }

        /// <summary>
        /// Creates a new ship with stats from a file
        /// </summary>
        /// <param name="name">File path in res/ship/</param>
        public Ship(string name) {
            #region Ship Stats
            using (XmlReader reader = XmlReader.Create("res/ship/" + name)) {
                while (reader.Read()) {
                    if (reader.IsStartElement()) {
                        switch (reader.Name) {
                            case "Name":
                                reader.Read(); name = reader.Value; break;
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
            #endregion
        }

        public void DisplayStats() {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Health: " + maxHealth);
            Console.WriteLine("Velocity: " + velocity);
            Console.WriteLine("Shield: " + maxShield);
            Console.WriteLine("Shield regeneration rate: " + shieldRegen);
        }
    }
}
