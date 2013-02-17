using System;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Starfield {
        private List<Tuple<int, int, int> stars = new List<Vector2i>();
        private int offsetX = 0, offsetY = 0;
        private Texture texture1, texture2, texture3;

        public Starfield(int count, Color color) {
            texture1 = new Texture(new Image(1, 1, color));
            texture2 = new Texture(new Image(2, 2, color));
            texture3 = new Texture(new Image(3, 3, color));

            Random random = new Random();

            for (int i = 0; i < count; i++) {
                stars.Add(Tuple.Create(random.Next(Game.WindowWidth), random.Next(Game.WindowHeight), random.Next(0, 4)));
            }
        }

        public void Draw(ref RenderWindow window) {
            foreach (Tuple<int, int. int> position in stars) {
                Sprite sprite = new Sprite(texture);
                sprite.Position = new Vector2f(position.X + offsetX, position.Y + offsetY);

                window.Draw(sprite);
            }
        }
    }
}
