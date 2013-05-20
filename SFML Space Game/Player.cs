using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

using SFML.Graphics;
using SFML.Window;

using SpaceGame;
using SpaceGame.Extension;
using System.Threading;

namespace SpaceGame {
    public class Player : DrawableGameObject {
        #region Graphics
        private Texture texture;

        private Vector2i moveLocation;
        private bool move;

        public FloatRect Bounds { get { return sprite.GetGlobalBounds(); } }

        private float rotation;

        private const float radianConversian = (float)(Math.PI / 180);
        private const float degreeConversion = (float)(180 / Math.PI);
        #endregion

        #region Networking
        Socket client;
        #endregion

        WeaponsProvider.Weapon weapon = WeaponsProvider.GetWeapon("Missile");   

        public Player() {
            #region Graphics
            texture = new Texture(@"res\image\BattleCruiserNoEngines.png");
            sprite = new Sprite(texture);

            sprite.Origin = new Vector2f(sprite.Texture.Size.X / 2, sprite.Texture.Size.Y / 2);

            sprite.Position = new Vector2f(200, Game.WindowHeight / 2);
            sprite.Scale = new Vector2f(0.3f, 0.3f);

            sprite.Texture.Smooth = true;
            #endregion

            #region Networking
            new Thread(new ThreadStart(Connect), 0).Start();
            #endregion
        }

        private void Connect() {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            try {
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse("50.156.12.144"), 9186);
                client.Connect(ip); // localhost = ip

                Console.WriteLine("Sending data...");

                byte[] data = Encoding.ASCII.GetBytes("Player created");
                int dataSent = client.Send(data);

                Console.WriteLine("INFO: Data sent");

                Console.WriteLine("INFO Receinving data...");
                dataSent = client.Receive(data);
                Console.WriteLine("INFO: Data = {0}", Encoding.ASCII.GetString(data));
            }
            catch (Exception e) {
                Console.WriteLine("ERROR: Networking exception in Player!\n" + e.ToString());
            }
        }

        public void Update(RenderWindow window) {
            #region Networking

            #endregion

            #region Movement
            if (Mouse.IsButtonPressed(Mouse.Button.Left) && Game.Focused) {
                moveLocation = Mouse.GetPosition(window);
                move = true;
            }

            if (move) {
                if (Near(sprite.Position, moveLocation.ToVector2f(), 20)) {
                    move = false;
                }
                else {
                    Vector2f direction = new Vector2f((moveLocation.X - sprite.Position.X), (moveLocation.Y - sprite.Position.Y)).Normalize();
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

                    Vector2f forward = new Vector2f((float)Math.Cos(sprite.Rotation * radianConversian), (float)Math.Sin(sprite.Rotation * radianConversian)).Normalize();

                    forward *= 2;
                    sprite.Position += forward;
                }
            }
            #endregion
        }


        #region Math Helper Functions
        private float AngleBetweenVectors(Vector2f a, Vector2i b) {
            return (float)((180 / Math.PI) * Math.Atan2(b.Y - a.Y, b.X - a.X));
        }

        private bool Near(Vector2f a, Vector2f b, int precision) {
            if (!(a.X - precision < b.X && a.X + precision > b.X)) return false;
            if (!(a.Y - precision < b.Y && a.Y + precision > b.Y)) return false;
            return true;
        }
        #endregion
    }
}
