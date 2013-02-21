using System;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Menu {
        public delegate void MenuButtonClickedHandler(object sender, EventArgs args);

        private static Font font = new Font("res/font.otf");

        class MenuButton : DrawableGameObject{
            private Text text;


            private RectangleShape shape;

            public event MenuButtonClickedHandler Clicked;

            #region Menu Button Class
            public MenuButton(string text, float position) {
                this.text = new Text(text, font, 48);

                shape = new RectangleShape();

                shape.Size = new Vector2f(200, 75);
                shape.Origin = new Vector2f(200 / 2, 75 / 2);
                shape.Position = new Vector2f(Game.WindowWidth / 2, position);

                shape.OutlineColor = Color.Black;
                shape.OutlineThickness = 3;

                shape.FillColor = Color.White;
            }
            #endregion

            public override void Update(RenderWindow window) {
                
            }

            public override void Draw(ref RenderWindow window) {
                
            }
        }

        // class
    }
}
