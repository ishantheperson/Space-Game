using System;
using System.IO;
using System.Collections.Generic;

namespace SpaceGame {
    public static class ShipTypes {
        /// <summary>
        /// Reads all the ship types from the specified file
        /// </summary>
        /// <param name="filePath">File name in res/ship/</param>
        /// <returns></returns>
        public static List<string> GetTypes(string fileName) {
            string[] lines = File.ReadAllLines(@"res/ship/" + fileName);

            List<string> types = new List<string>();

            foreach (string type in lines) {
                types.Add(type);
            }

            return types;
        }
    }
}
