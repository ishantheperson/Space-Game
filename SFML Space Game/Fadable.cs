using System;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Fadable : DrawableGameObject {
        private int opacity = 0;
        private Sprite sprite;
        private Texture texture;

        private bool flip = false;

        public delegate void FadeCompletedEventHandler(object sender, EventArgs args);
        public event FadeCompletedEventHandler Completed;

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
            if (opacity < 255 && !flip) sprite.Color = new Color(0, 0, 0, opacity++);
            else flip = true;

            if (opacity == 0) FadeCompletedEventHandler(this, EventArgs.Empty);
            if (flip) sprite.Color = new Color(0, 0, 0, opacity--);
        } 

        public override void Draw(ref RenderWindow window) {
            window.Draw(sprite);
        }
    }
}
