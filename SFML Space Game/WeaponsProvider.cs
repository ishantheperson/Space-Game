using System;
using System.Xml;

namespace SpaceGame {
    public static class WeaponsProvider {
        private static XmlDocument xmlDocument = new XmlDocument();
        private static bool loaded = false;


        public struct Weapon {  
            /// <summary>
            /// Descriptive Name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Weapon damage
            /// </summary>
            public int Damage { get; set; }

            /// <summary>
            /// Weapon fire rate
            /// </summary>
            public float FireRate { get; set; }

            public override string ToString() {
                return "Name: " + Name + ", Damage: " + Damage + ", Fire Rate: " + FireRate;
            }
        }

        /// <summary>
        /// Gets the weapon from weapons.xml called <i>name</i>
        /// </summary>
        /// <param name="name">The name of the weapon</param>
        /// <returns>Weapon object from weapons.xml</returns>
        public static Weapon GetWeapon(string name) {
            if (!loaded) xmlDocument.Load(@"res/weapon/weapons.xml");

            Weapon weapon = new Weapon();

            XmlNode element = xmlDocument.GetElementsByTagName(name)[0];
            weapon.Name = element["Name"].InnerXml;
            weapon.Damage = int.Parse(element["Damage"].InnerXml);
            weapon.FireRate = float.Parse(element["FireRate"].InnerXml);

            return weapon;
        }
    }
}
