using System;
using SFML.Graphics;

namespace SpaceGame {
    /// <summary>
    /// Base class for all Drawable Game Objects. As 
    /// these have no functionality on their own, they cannot be 
    /// created. Implements Draw/Update method for use in 
    /// Level Object lsts
    /// </summary>
    public abstract class DrawableGameObject {
        public virtual void Initialize() { }
        public virtual void Draw(ref RenderWindow window) { }
        public virtual void Update(RenderWindow window) { }
    }
}
