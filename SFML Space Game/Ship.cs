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
        public string ShipType;
        public int MaxHealth;
        public int Velocity;
        public int MaxShield;
//<<<<<<< HEAD
//=======
        public int SheildRegen;
        
        public void Read(string location)
        {
            using (XmlReader reader = XmlReader.Create(@"res\ship\" + location))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "Statistics":
                                reader.Read();
                                while (true)
                                {
                                    if (reader.Name == "Statistics" && reader.NodeType == XmlNodeType.EndElement) break;
                                    reader.Read();
                                    if (reader.IsStartElement())
                                    {
                                        string val = reader.Value;
                                        int ival = 0;
                                        foreach (char c in val)
                                            if (Char.IsDigit(c)) ival += c;
                                        ival = int.Parse(val);
                                        switch (reader.Name)
                                        {
                                            case "Type":
                                                this.ShipType = reader.Value; break;
                                            case "Health":
                                                this.MaxHealth = ival; break;
                                            case "Velocity":
                                                this.Velocity = ival; break;
                                            case "Shield":
                                                this.MaxShield = ival; break;
                                            case "ShieldRegen":
                                                this.SheildRegen = ival; break;
                                        }

                                    }
                                }
                                break;
                        }
                    }
                }
            }
        }
         
/*>>>>>>> Its still not working

        public int ShieldRegen;

        public void Read(string location) {
            using (XmlReader reader = XmlReader.Create(location)) {
                while (reader.Read()) {
                    if (reader.IsStartElement()) {
                        switch (reader.Name) {
                            case "Statistics":
                                reader.Read();
                                while (reader.Read()) {
                                    if (reader.Name == "Statistics" && reader.NodeType == XmlNodeType.EndElement) break;
                                    if (reader.IsStartElement()) {
                                        switch (reader.Name) {
                                            case "Type":
                                                this.ShipType = reader.Value; break;
                                            case "Health":
                                                this.MaxHealth = int.Parse(reader.Value); break;
                                            case "Velocity":
                                                this.Velocity = int.Parse(reader.Value); break;
                                            case "Shield":
                                                this.MaxShield = int.Parse(reader.Value); break;
                                            case "ShieldRegen":
                                                this.ShieldRegen = int.Parse(reader.Value); break;
                                        }

                                    }
                                    break;
                                }
                                break;
                        }
                    }
                }
            }
        }*/

        public void DisplayStats() {
            Console.WriteLine("Health" + MaxHealth);
        }
    }
}
