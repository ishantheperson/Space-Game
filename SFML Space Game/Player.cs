using System;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Player {
        private Texture texture;
        private Sprite sprite;

        public Player() {
            texture = new Texture(@"res/image/player.png");
            sprite = new Sprite(texture);

            sprite.Origin = new Vector2f(sprite.Texture.Size.X / 2, sprite.Texture.Size.Y / 2);
            sprite.Scale = new Vector2f(0.1f, 0.1f);

            sprite.Position = new Vector2f((Game.WindowWidth / 2) - (sprite.Texture.Size.X / 2), Game.WindowHeight - 200);
        }

        public void Update() {

        }

        public void Draw(ref RenderWindow window) {
            window.Draw(sprite);
        }
    }
}
