using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
//JaJuan Webster
//Professor Cascioli
//MonoGame Button

namespace Webster_MonoGame_Button
{
    class Button
    {
        //Attributes
        SpriteBatch spriteBatch;
        public Texture2D image;
        public Rectangle rectangle;
        public Color color;

        public Button(SpriteBatch sb, Texture2D img, Color col, int x, int y)
        {
            spriteBatch = sb;
            image = img;
            rectangle = new Rectangle(x, y, img.Width, img.Height);
            color = col;
        }

        public bool MouseInsideButton()
        {
            MouseState ms = Mouse.GetState();
            
            //Statement if the mouse position is "inside" the button
            if (ms.X >= rectangle.X && ms.X <= rectangle.Right || ms.Y >= rectangle.Y && ms.Y <= rectangle.Bottom)
            {
                return true;
            }

            return false;
        }

        public bool Clicked()
        {
            MouseState ms = Mouse.GetState();

            if (ms.LeftButton == ButtonState.Pressed)
            {
                //Statement if the mouse position is "inside" the button
                if (ms.X >= rectangle.X && ms.X <= rectangle.Right || ms.Y >= rectangle.Y && ms.Y <= rectangle.Bottom)
                {
                    return true;
                }
            }

            return false;
        }

        public void Draw()
        {
            spriteBatch.Draw(image, rectangle, color);
        }
    }
}
