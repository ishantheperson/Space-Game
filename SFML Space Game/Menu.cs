using System;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SpaceGame {
    public class Menu : DrawableGameObject {
        public delegate void MenuButtonClickedHandler(object sender, EventArgs args);
        public Event theEvent = new Event();
        private static Font font = new Font("res/font.ttf");

        #region Menu Button Class
        public class MenuButton {
            private Text text;
            private RectangleShape shape;

            public event MenuButtonClickedHandler Clicked;
            private bool beingClicked = false;

            public MenuButton(string text, float position, MenuButtonClickedHandler onClicked) {
                this.text = new Text(text, font, 48);

                shape = new RectangleShape();

                #region Shape Appearance
                shape.Size = new Vector2f(200, 75);
                shape.Position = new Vector2f(Game.WindowWidth / 2 - 100, position);

                shape.OutlineColor = Color.White;
                shape.OutlineThickness = 3;

                shape.FillColor = new Color(255, 255, 255, 100);
                #endregion
                this.text.Origin = new Vector2f(this.text.GetLocalBounds().Width / 2, this.text.GetLocalBounds().Height / 2);
                this.text.Position = new Vector2f(shape.Position.X + shape.Size.X / 2, shape.Position.Y + shape.Size.Y / 2);

                Clicked += onClicked;
            }

            public void Update(RenderWindow window) {
                float x1, y1, x2, y2;

                x1 = shape.Position.X; // rect.Left; 
                y1 = shape.Position.Y + shape.Size.Y; // rect.Top + rect.Height;

                x2 = shape.Position.X + shape.Size.X; // rect.Left + rect.Width;
                y2 = shape.Position.Y; // rect.Top;

                Vector2i point = Mouse.GetPosition(window);
                if ((x1 <= point.X) && (point.X <= x2) && (y1 >= point.Y) && (point.Y >= y2)) {
                    if (Mouse.IsButtonPressed(Mouse.Button.Left)) {
                        beingClicked = true;
                        shape.FillColor = new Color(255, 255, 255, 200);
                    }
                    else if (beingClicked) {
                        Clicked(this, EventArgs.Empty);
                        shape.FillColor = new Color(255, 255, 255, 0);
                        beingClicked = false;
                    }
                    else {
                        shape.FillColor = new Color(255, 255, 255, 150);
                    }
                }
                else {
                    shape.FillColor = new Color(255, 255, 255, 100);
                    beingClicked = false;
                }
            }

            public void Draw(ref RenderWindow window) {
                window.Draw(shape);
                window.Draw(text);
            }
        }
        #endregion

        public struct MenuButtonInitializer {
            public string Text;
            public Action<object, EventArgs> Click;

            public MenuButtonInitializer(string text, Action<object, EventArgs> click) {
                this.Click = click;
                this.Text = text;
            }
        }

        List<MenuButton> buttons = new List<MenuButton>();

        public Menu(params MenuButtonInitializer[] buttons) {
            //this.buttons.Add(new MenuButton("Play", 200, (sender, args) => Game.GameState = Game.GameStates.Game));
            //this.buttons.Add(new MenuButton("Options", 300, (sender, args) => { })); // do nothing
            //this.buttons.Add(new MenuButton("Exit", 400, (sender, args) => Game.GameState = Game.GameStates.Exit));
            int offset = 200;
            foreach (MenuButtonInitializer button in buttons) {
                this.buttons.Add(new MenuButton(button.Text, offset, (sender, args) => { button.Click(this, EventArgs.Empty); }));
                offset += 100;
            }
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
