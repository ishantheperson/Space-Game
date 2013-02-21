using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using SFML.Graphics;
using SFML.Window;
<<<<<<< HEAD

using System.IO;

=======
>>>>>>> 0e43460393fc761192964dabcf62cb3e194703a6

namespace SpaceGame {
    public class Ship {
        private string shipType;
        private int maxHealth;
        private int velocity;
        private int maxShield;
        private int shieldRegen;

<<<<<<< HEAD

        public int ShieldRegen;

       



        public void Read(string name) {
=======
        public Ship(string name) {
>>>>>>> 0e43460393fc761192964dabcf62cb3e194703a6
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
<<<<<<< HEAD
                                reader.Read(); this.ShieldRegen = int.Parse(reader.Value); break;

=======
                                reader.Read(); shieldRegen = int.Parse(reader.Value); break;
>>>>>>> 0e43460393fc761192964dabcf62cb3e194703a6
                        }
                    }
                }
            }
        }
<<<<<<< HEAD

         



        public void DisplayStats() {
            Console.WriteLine("Type: " + ShipType);
            Console.WriteLine("Health: " + MaxHealth);
            Console.WriteLine("Velocity: " + Velocity);
            Console.WriteLine("Shield: " + MaxShield);
            Console.WriteLine("Shield regeneration rate: " + ShieldRegen);

=======

        public void DisplayStats() {
            Console.WriteLine("Health: " + maxHealth);
>>>>>>> 0e43460393fc761192964dabcf62cb3e194703a6
        }
    }
}
