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
                                this.ShipType = reader.Value; break;
                            case "Health":
                                reader.Read(); this.MaxHealth = int.Parse(reader.Value); break;
                            case "Velocity":
                                this.Velocity = int.Parse(reader.Value); break;
                            case "Shield":
                                this.MaxShield = int.Parse(reader.Value); break;
                            case "ShieldRegen":
                                this.ShieldRegen = int.Parse(reader.Value); break;
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
