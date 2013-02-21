using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Ship {
        public string ShipType;
        public int MaxHealth;
        public int Velocity;
        public int MaxShield;

        public int ShieldRegen;

        public void Read(string name) {
            using (XmlReader reader = XmlReader.Create("res/ship/" + name)) {
                while (reader.Read()) {
                    if (reader.IsStartElement()) {
                        switch (reader.Name) {
                            case "Type":
                                reader.Read(); this.ShipType = reader.Value; break;
                            case "Health":
                                reader.Read(); this.MaxHealth = int.Parse(reader.Value); break;
                            case "Velocity":
                                reader.Read(); this.Velocity = int.Parse(reader.Value); break;
                            case "Shield":a
                                reader.Read(); this.MaxShield = int.Parse(reader.Value); break;
                            case "ShieldRegen":
                                reader.Read(); this.ShieldRegen = int.Parse(reader.Value); break;
                        }
                    }
                }
            }
        }

        public void DisplayStats() {
            Console.WriteLine("Health" + MaxHealth);
        }
    }
}
