using System;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Player {
        private Texture texture;
        private Sprite sprite;

        private Vector2i moveLocation;
        private bool moving;
        private int turnRate = 1;
        float rotation;

        private const float radianConversian = (float)(Math.PI / 180);

        public Player() {
            texture = new Texture(@"res/image/player.png");
            sprite = new Sprite(texture);

            sprite.Origin = new Vector2f(sprite.Texture.Size.X / 2, sprite.Texture.Size.Y / 2);

            sprite.Position = new Vector2f(200, Game.WindowHeight / 2);
            sprite.Scale = new Vector2f(0.3f, 0.3f);
        }

        public void Update(RenderWindow window) {
            if (Mouse.IsButtonPressed(Mouse.Button.Left)) {
                moveLocation = Mouse.GetPosition(window);

                // calculate angle from here to there
                float angle = AngleBetweenVectors(sprite.Position, moveLocation);
                Vector2i direction = new Vector2i((int)(moveLocation.X - sprite.Position.X), (int)(moveLocation.Y - sprite.Position.Y));
                rotation = (float)((float)(180 / Math.PI) * Math.Atan2(direction.Y, direction.X));

                moving = true;
            }

            if (moving) {
                if ((int)(sprite.Rotation - rotation) == 0 && sprite.Position.Equals(new Vector2f(moveLocation.X, moveLocation.Y))) {
                    moving = false;
                }
                else if (rotation > sprite.Rotation) {
                    sprite.Rotation += 1;
                }
                else if (rotation < sprite.Rotation) {
                    sprite.Rotation -= 1;
                }

                Vector2f forward = new Vector2f((float)Math.Cos(sprite.Rotation * radianConversian), (float) Math.Sin(sprite.Rotation * radianConversian));
                forward *= 2;
                sprite.Position += forward;
            }
        }

        public void Draw(ref RenderWindow window) {
            window.Draw(sprite);
        }

        float AngleBetweenVectors(Vector2f a, Vector2i b) {
            return (float)((180 / Math.PI) * Math.Atan2(b.Y - a.Y, b.X - a.X));
        }
    }
}
