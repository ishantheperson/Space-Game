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
        float rotation;

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

                // calculate angle from here to there
                float angle = AngleBetweenVectors(sprite.Position, moveLocation);
                Console.WriteLine(angle + " " + sprite.Rotation);
                Vector2i direction = new Vector2i((int)(moveLocation.X - sprite.Position.X), (int)(moveLocation.Y - sprite.Position.Y));
                rotation = (float)((float)(180 / Math.PI) * Math.Atan2(direction.Y, direction.X));

                if (rotation > sprite.Rotation) {
                    sprite.Rotation += 1;
                    moving = true;
                }
                else if (rotation < sprite.Rotation) {
                    sprite.Rotation -= 1;
                    moving = true;
                }
                else if (rotation == sprite.Rotation) {
                    moving = false;
                }
<<<<<<< HEAD

                Vector2f forward = new Vector2f( (moveLocation.X - sprite.Position.X), moveLocation.Y - sprite.Position.Y);
                
=======
>>>>>>> 4d74119e01b0592210f51672357a293b422d35c7
            }

            else if (moving) {
                if (rotation > sprite.Rotation) {
                    sprite.Rotation += 1;
                }
                else if (rotation < sprite.Rotation) {
                    sprite.Rotation -= 1;
                }
                else if (rotation == sprite.Rotation) {
                    moving = false;
                }
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
