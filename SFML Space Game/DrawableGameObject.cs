using System;
using SFML.Graphics;

namespace SpaceGame {
    /// <summary>
    /// Base class for all Drawable Game Objects.
    /// </summary>
    public class DrawableGameObject {
        protected Sprite sprite;

        public virtual void Draw(ref RenderWindow window) {
            window.Draw(sprite);
        }
        public virtual void Update() { }
    }
}
