using System;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Fadable : DrawableGameObject {
        private int opacity = 0;
        private Sprite sprite;
        private Texture texture;

        /// <summary>
        /// Creates a new Fadable 
        /// </summary>
        /// <param name="file">File path</param>
        /// <param name="position">Position of fadable</param>
        public Fadable(string file, Vector2f position) {
            texture = new Texture(@"res/image/" + file);
            texture.Smooth = true;

            sprite = new Sprite(texture);
            sprite.Position = position;
            sprite.Color = new Color(0, 0, 0, 0);
        }

        public override void Update(RenderWindow window) {
            sprite.Color = new Color(0, 0, 0, opacity++);
        } 

        public override void Draw(ref RenderWindow window) {
            window.Draw(sprite);
        }
    }
}
