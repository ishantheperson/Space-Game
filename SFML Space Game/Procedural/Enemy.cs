using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML.Graphics;
using SFML.Window;

using SpaceGame.Extension;
namespace SpaceGame.Procedural
{
    class Enemy : IDrawable
    {
        private Sprite sprite;
        private Texture texture;
        private float rotation;
        private const float DegreeConversion = (float)(180 / Math.PI);
        private const float RadianConversion = (float)(Math.PI / 180);
        private bool move;
        int range = 500; //yet to be defined for different enemies
        public Enemy()
        {
            texture = new Texture(@"/res/image/player.png");
            sprite = new Sprite(texture);
        }

        public void Update(Player player)
        {

            if (Near(sprite.Position, player.sprite.Position, range))
            {
                
                if (Near(sprite.Position, player.sprite.Position, 50) ==  false)
                {
                    Vector2f direction = new Vector2f((sprite.Position.X - player.sprite.Position.X), (sprite.Position.Y - player.sprite.Position.Y)).Normalize();
                    rotation = DegreeConversion * (float)Math.Atan2(direction.X, direction.Y);

                    if (Math.Abs(rotation) > 180)
                    {
                        rotation -= 180;
                        rotation *= -1;
                    }
                    if (rotation > 0)
                    {
                        if (Math.Abs(sprite.Rotation - rotation) > 0)
                        {
                            sprite.Rotation = rotation;
                            sprite.Rotation += 3;
                        }
                    }
                    if (rotation > sprite.Rotation)
                    {
                        if (Math.Abs(sprite.Rotation - rotation) < 0)
                        {
                            sprite.Rotation = rotation;
                            sprite.Rotation -= 3;
                        }
                    }
                    Vector2f forward = new Vector2f((float)Math.Cos(sprite.Rotation * RadianConversion), (float)Math.Sin(sprite.Rotation * RadianConversion));
                    forward *= 2;
                    sprite.Position += forward;
                }
            }
        }
        private bool Near(Vector2f a, Vector2f b, int precision)
        {
            if (!(a.X - precision < b.X && a.X + precision > b.X)) return false;
            if (!(a.Y - precision < b.Y && a.Y + precision > b.Y)) return false;
            return true;
        }
    }
}

