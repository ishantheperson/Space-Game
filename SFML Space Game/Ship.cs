using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame
{
    public class Ship
    {
        public int MaxHealth;
        public int Velocity;
        public int MaxSheild;
        public int SheildRegen;
        public void Read(string location)
        {
            using (XmlReader reader = XmlReader.Create(location))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "Health":
                                

                        }
                    }
                }
            }
        }
    }
}
