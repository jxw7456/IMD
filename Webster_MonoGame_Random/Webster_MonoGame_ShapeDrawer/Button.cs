using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
//JaJuan Webster
//Professor Cascioli
//MonoGame Random

namespace Webster_MonoGame_Random
{
    class Button
    {
        //Attributes
        SpriteBatch spriteBatch;
        public Texture2D image;
        public Rectangle rectangle;
        public Color color;

        //Constructor
        public Button(SpriteBatch sb, Texture2D img, Color col, int x, int y)
        {
            spriteBatch = sb;
            image = img;
            rectangle = new Rectangle(x, y, img.Width, img.Height);
            color = col;
        }

        /// <summary>
        /// returns a bool that determines whether the mouse cursor is inside the button or not
        /// </summary>
        /// <returns>boolean</returns>
        public bool MouseInsideButton()
        {
            MouseState ms = Mouse.GetState();
            
            //Statement if the mouse position is "inside" the button
            if (ms.X >= rectangle.X && ms.X <= rectangle.Right && ms.Y >= rectangle.Y && ms.Y <= rectangle.Bottom)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// returns a bool that determines if the mouse left button is being clicked
        /// </summary>
        /// <returns>boolean</returns>
        public bool Clicked()
        {
            MouseState ms = Mouse.GetState();

            if (ms.LeftButton == ButtonState.Pressed && MouseInsideButton() == true)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// draws the button image
        /// </summary>
        public void Draw()
        {
            spriteBatch.Draw(image, rectangle, color);
        }
    }
}
