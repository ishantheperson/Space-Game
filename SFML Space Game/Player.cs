using System;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

using SpaceGame;
using SpaceGame.Extension;

namespace SpaceGame {
    public class Player : DrawableGameObject {
        #region Graphics
        private Texture texture;
        public Sprite sprite;

        private Vector2i moveLocation;
        private bool move;

        public FloatRect Bounds { get { return sprite.GetGlobalBounds(); } }

        private float rotation;

        private const float radianConversian = (float)(Math.PI / 180);
        private const float degreeConversion = (float)(180 / Math.PI);
        #endregion

        WeaponsProvider.Weapon weapon = WeaponsProvider.GetWeapon("Missile");

        public Player() {
            texture = new Texture(@"res\image\BattleCruiserNoEngines.png");
            sprite = new Sprite(texture);

            sprite.Origin = new Vector2f(sprite.Texture.Size.X / 2, sprite.Texture.Size.Y / 2);

            sprite.Position = new Vector2f(200, Game.WindowHeight / 2);
            sprite.Scale = new Vector2f(0.3f, 0.3f);

            sprite.Texture.Smooth = true;  
        }

        public override void Update(RenderWindow window) {
            if (Mouse.IsButtonPressed(Mouse.Button.Left) && Game.Focused) {
                moveLocation = Mouse.GetPosition(window);
                move = true;

                Console.WriteLine(weapon);
            }

            if (move) {
                if (Near(sprite.Position, moveLocation.ToVector2f(), 20)) {
                    move = false;
                }
                else {
                    Vector2f direction = Normalize(new Vector2f((moveLocation.X - sprite.Position.X), (moveLocation.Y - sprite.Position.Y)));
                    rotation = degreeConversion * (float)Math.Atan2(direction.Y, direction.X);

                    if (Math.Abs(rotation) > 180) { // should not go more than 180
                        rotation -= 180;
                        rotation *= -1;
                    }

                    if (rotation > 0) {
                        if (Math.Abs(sprite.Rotation - rotation) < 0) sprite.Rotation = rotation;
                        sprite.Rotation += 3;
                    }
                    if (rotation < sprite.Rotation) {
                        if (Math.Abs(sprite.Rotation - rotation) < 0) sprite.Rotation = rotation;
                        sprite.Rotation -= 3;
                    }

                    Vector2f forward = Normalize(new Vector2f((float)Math.Cos(sprite.Rotation * radianConversian), (float)Math.Sin(sprite.Rotation * radianConversian)));

                    forward *= 2;
                    sprite.Position += forward;
                }
            }
        }
        
        public override void Draw(ref RenderWindow window) {
            window.Draw(sprite);
        }

        private float AngleBetweenVectors(Vector2f a, Vector2i b) {
            return (float)((180 / Math.PI) * Math.Atan2(b.Y - a.Y, b.X - a.X));
        }

        private bool Near(Vector2f a, Vector2f b, int precision) {
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
