using System;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Fadable : DrawableGameObject {
        private int opacity;
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
        }

        public override void Draw(ref RenderWindow window) {
            
        }
    }
}
