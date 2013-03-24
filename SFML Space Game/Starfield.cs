using System;
using System.Collections.Generic;
using System.Timers;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Starfield : DrawableGameObject {
        private List<Tuple<int, int, int>> stars = new List<Tuple<int, int, int>>();
        public Vector2i offset;
        private Texture texture1, texture2, texture3;

        private int count;
        private Color color;

        /// <summary>
        /// Initializes a new Starfield
        /// </summary>
        /// <param name="count">Amount of stars</param>
        /// <param name="color">Star color</param>
        /// <param name="size">The size of the starfield</param>
        public Starfield(int count, Color color, Vector2i size) {
            texture1 = new Texture(new Image(1, 1, color));
            texture2 = new Texture(new Image(2, 2, color));
            texture3 = new Texture(new Image(3, 3, color));

            Random random = new Random();

            this.count = count;
            this.color = color;

            for (int i = 0; i < count; i++) {
                stars.Add(Tuple.Create(random.Next(size.X), random.Next(size.Y), random.Next(0, 3)));
            }
        }

        public override void Draw(ref RenderWindow window) {
            foreach (Tuple<int, int, int> tuple in stars) {
                Sprite sprite = new Sprite();

                switch (tuple.Item3) {
                    case 0:
                        sprite = new Sprite(texture1);
                        break;

                    case 1:
                        sprite = new Sprite(texture2);
                        break;

                    case 2:
                        sprite = new Sprite(texture3);
                        break;
                }
                sprite.Position = new Vector2f(tuple.Item1 + offset.X, tuple.Item2 + offset.Y);

                window.Draw(sprite);
            }
        }
    }
}
