using System;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Menu : DrawableGameObject {
        public delegate void MenuButtonClickedHandler(object sender, EventArgs args);
        public Event theEvent = new Event();
        private static Font font = new Font("res/font.otf");

        #region Menu Button Class
        class MenuButton {
            private Text text;

            private RectangleShape shape;

            public event MenuButtonClickedHandler Clicked;

            public MenuButton(string text, float position, MenuButtonClickedHandler onClicked) {
                this.text = new Text(text, font, 48);

                shape = new RectangleShape();

                #region Shape Appearance
                shape.Size = new Vector2f(200, 75);
                shape.Origin = new Vector2f(200 / 2, 75 / 2);
                shape.Position = new Vector2f(Game.WindowWidth / 2, position);

                shape.OutlineColor = Color.Black;
                shape.OutlineThickness = 3;

                shape.FillColor = Color.White;
                #endregion

                this.text.Origin = new Vector2f(this.text.GetLocalBounds().Width / 2, this.text.GetLocalBounds().Height / 2);
                this.text.Position = new Vector2f(shape.Position.X + shape.Size.X / 2, shape.Position.Y + shape.Size.Y / 2);

                Clicked += onClicked;
            }

            public void Update(RenderWindow window) {
                if (Mouse.IsButtonPressed(Mouse.Button.Left)) {
                    float x1, y1, x2, y2;

                    x1 = shape.Position.X; // rect.Left; 
                    y1 = shape.Position.Y + shape.Size.Y; // rect.Top + rect.Height;

                    x2 = shape.Position.X + shape.Size.X; // rect.Left + rect.Width;
                    y2 = shape.Position.Y; // rect.Top;

                    Vector2i point = Mouse.GetPosition(window);
                    if ((x1 <= point.X) && (point.X <= x2) && (y1 <= point.X) && (point.Y <= y2)) {
                        // inside
                        Console.WriteLine("INFO: button " + text + " clicked");
                        Clicked(this, EventArgs.Empty);
                    }
                }
            }

            public void Draw(ref RenderWindow window) {
                window.Draw(shape);
                window.Draw(text);
            }
        }
        #endregion

        List<MenuButton> buttons = new List<MenuButton>();

        public Menu() {
            buttons.Add(new MenuButton("Play", 200, (sender, args) => Game.GameState = Game.GameStates.Game));
        }

        public override void Update(RenderWindow window) {
            foreach (MenuButton button in buttons) {
                button.Update(window);
            }
        }

        public override void Draw(ref RenderWindow window) {
            foreach (MenuButton button in buttons) {
                button.Draw(ref window);
            }
        }
        // class
    }
}
