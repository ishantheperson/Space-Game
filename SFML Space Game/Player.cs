using System;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Player {
        private Texture texture;
        private Sprite sprite;

        private Vector2i moveLocation;

        public Player() {
            texture = new Texture(@"res/image/player.png");
            sprite = new Sprite(texture);

            sprite.Origin = new Vector2f(sprite.Texture.Size.X / 2, sprite.Texture.Size.Y / 2);

            sprite.Position = new Vector2f(200, Game.WindowHeight / 2);
            sprite.Scale = new Vector2f(0.3f, 0.3f);
        }

        public void Update(RenderWindow window) {
            if (Mouse.IsButtonPressed(Mouse.Button.Right)) {
                moveLocation = Mouse.GetPosition(window);
            }
            else {
                moveLocation = new Vector2i((int) sprite.Position.X, (int) sprite.Position.Y);
            }

            // calculate angle from here to there
            float angle = AngleBetweenVectors(sprite.Position, moveLocation);
            Console.WriteLine(angle + " " + sprite.Rotation);
            Vector2i direction = new Vector2i((int) (moveLocation.X - sprite.Position.X), (int)(moveLocation.Y - sprite.Position.Y));
            float rotation = (float)((float)(180 / Math.PI) * Math.Atan2(direction.Y, direction.X));
            sprite.Rotation = rotation;
        }

        public void Draw(ref RenderWindow window) {
            window.Draw(sprite);
        }

        float AngleBetweenVectors(Vector2f a, Vector2i b) {
            return (float)((180 / Math.PI) * Math.Atan2(b.Y - a.Y, b.X - a.X));
        }
    }
}
