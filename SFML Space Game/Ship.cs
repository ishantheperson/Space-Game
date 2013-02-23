using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using SFML.Graphics;
using SFML.Window;


using System.IO;



namespace SpaceGame {
    public class Ship {
        private string shipType;
        private int maxHealth;
        private int velocity;
        private int maxShield;
        private int shieldRegen;

<<<<<<< HEAD

       



=======
        public int ShieldRegen;
>>>>>>> 736957e7d07a0e25aba5a81540fd59ee93604ba9

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
<<<<<<< HEAD
                            case "shieldRegen":
=======
                            case "ShieldRegen":

                                reader.Read(); this.ShieldRegen = int.Parse(reader.Value); break;

>>>>>>> 736957e7d07a0e25aba5a81540fd59ee93604ba9
                                reader.Read(); shieldRegen = int.Parse(reader.Value); break;

                        }
                    }
                }
            }
        }
<<<<<<< HEAD
    


         


=======
>>>>>>> 736957e7d07a0e25aba5a81540fd59ee93604ba9

        public void DisplayStats() {
            Console.WriteLine("Type: " + shipType);
            Console.WriteLine("Health: " + maxHealth);
            Console.WriteLine("Velocity: " + velocity);
            Console.WriteLine("Shield: " + maxShield);
            Console.WriteLine("Shield regeneration rate: " + shieldRegen);
        }
    }
}
