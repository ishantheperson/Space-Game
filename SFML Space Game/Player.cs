using System;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Player {
        private Texture texture;
        private Sprite sprite;

        private Vector2i moveLocation;
        private bool rotate;
        private bool move;

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
            if (Mouse.IsButtonPressed(Mouse.Button.Left) && Game.Focused) {
                moveLocation = Mouse.GetPosition(window);

                // calculate angle from here to there
                float angle = AngleBetweenVectors(sprite.Position, moveLocation);
                Vector2i direction = new Vector2i((int)(moveLocation.X - sprite.Position.X), (int)(moveLocation.Y - sprite.Position.Y));
                rotation = (float)((float)(180 / Math.PI) * Math.Atan2(direction.Y, direction.X));

                rotate = true;
                move = true;
            }

            if (rotate) {
                if ((int)(sprite.Rotation - rotation) == 0) {
                    rotate = false;
                }
                else if (rotation > sprite.Rotation) {
                    sprite.Rotation += 1;
                }
                else if (rotation < sprite.Rotation) {
                    sprite.Rotation -= 1;
                }

            }

            if (move) {
                if (Vector2i.Equals(moveLocation, new Vector2i((int)sprite.Position.X, (int)sprite.Position.Y))) {
                    move = false;
                }
                else {
                    Console.WriteLine("X {0} Y {1} move x {2} y {3}", sprite.Position.X, sprite.Position.Y, moveLocation.X, moveLocation.Y);
                    Vector2f forward = Normalize(new Vector2f(moveLocation.X - sprite.Position.X, moveLocation.Y - sprite.Position.Y));

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

        /// <summary>
        /// Checks if <i>A</i> is within <i>Precision</i> of <i>B</i>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        private bool Near(float a, float b, int precision) {
            if (b - precision >= a || b + precision <= a) return true;
            else return false;
        }

        public Vector2f Normalize(Vector2f vector) {
            float distance = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y); // x^2 + y^2 == length (pythagorean theorum)
            return new Vector2f(vector.X / distance, vector.Y / distance);
        }
    }
}
