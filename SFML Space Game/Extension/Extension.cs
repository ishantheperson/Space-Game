using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame.Extension {
    public static class Conversion {
        public static IntRect ToIntRect(this FloatRect source) {
            return new IntRect((int)source.Left, (int)source.Top, (int)source.Width, (int)source.Height);
        }
        public static FloatRect ToFloatRect(this IntRect source) {
            return new FloatRect((float)source.Left, (float)source.Top, (float)source.Width, (float)source.Height);
        }

        public static Vector2f ToVector2f(this Vector2i source) {
            return new Vector2f((float)source.X, (float)source.Y);
        }
    }

    public static class MathHelper {
        public static Vector2f Normalize(this Vector2f vector) {
            float distance = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y); // x^2 + y^2 == length (pythagorean theorum)
            return new Vector2f(vector.X / distance, vector.Y / distance);
        }
    }
}
