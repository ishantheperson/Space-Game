using System;
using SFML.Graphics;

namespace SpaceGame {
    /// <summary>
    /// Base class for all Drawable Game Objects. As 
    /// these have no functionality on their own, they cannot be 
    /// created. Implements one Draw method for use in 
    /// Level Draw Lists
    /// </summary>
    public abstract class DrawableGameObject {
        public virtual void Draw(ref RenderWindow window) { }
    }
}
