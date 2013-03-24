using System;
using SFML.Graphics;

namespace SpaceGame {
    /// <summary>
    /// Base class for all Drawable Game Objects.
    /// </summary>
<<<<<<< HEAD
    public class DrawableGameObject {
        protected Sprite sprite;

        public virtual void Draw(ref RenderWindow window) {
            window.Draw(sprite);
        }
        public virtual void Update() { }
=======
    public interface IDrawable {
        void Draw(ref RenderWindow window);
        void Update();
>>>>>>> 88c8ecce42c3fb30a88adf72d7b063683649f698
    }
}
