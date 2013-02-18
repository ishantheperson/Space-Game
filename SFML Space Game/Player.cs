using System;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Player {
        private Texture texture;
        private Sprite sprite;

        private Vector2i moveLocation;
        private bool move;

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
            if (Mouse.IsButtonPressed(Mouse.Button.Left) && Game.Focused) {
                moveLocation = Mouse.GetPosition(window);

                // calculate angle from here to there

                move = true;
            }

            if (move) {
                if (Near(sprite.Position, moveLocation, 5)) {
                    move = false;
                }
                else {
                    float angle = AngleBetweenVectors(sprite.Position, moveLocation);
                    Vector2f direction = Normalize(new Vector2f((moveLocation.X - sprite.Position.X), (moveLocation.Y - sprite.Position.Y)));
                    rotation = (float)((float)(180 / Math.PI) * Math.Atan2(direction.Y, direction.X));

                    if (rotation > sprite.Rotation) {
                        sprite.Rotation += 1;
                    }
                    if (rotation < sprite.Rotation) {
                        sprite.Rotation -= 1;
                    }

                    Console.WriteLine("X {0} Y {1} R {4} move x {2} y {3}", sprite.Position.X, sprite.Position.Y, moveLocation.X, moveLocation.Y, sprite.Rotation);
                    // Vector2f forward = Normalize(new Vector2f(moveLocation.X - sprite.Position.X, moveLocation.Y - sprite.Position.Y));
                    Vector2f forward = Normalize(new Vector2f((float)Math.Cos(sprite.Rotation * radianConversian), (float)Math.Sin(sprite.Rotation * radianConversian)));

                    forward *= 2;
                    sprite.Position += forward;
                }
            }
        }

        public void Draw(ref RenderWindow window) {
            window.Draw(sprite);
        }

        private float AngleBetweenVectors(Vector2f a, Vector2i b) {
            return (float)((180 / Math.PI) * Math.Atan2(b.Y - a.Y, b.X - a.X));
        }

        private bool Near(Vector2f a, Vector2i b, int precision) {
            if (!(a.X - precision < b.X && a.X + precision > b.X)) return false;
            if (!(a.Y - precision < b.Y && a.Y + precision > b.Y)) return false;
            return true;
        }

        public Vector2f Normalize(Vector2f vector) {
            float distance = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y); // x^2 + y^2 == length (pythagorean theorum)
            return new Vector2f(vector.X / distance, vector.Y / distance);
        }
    }
}
