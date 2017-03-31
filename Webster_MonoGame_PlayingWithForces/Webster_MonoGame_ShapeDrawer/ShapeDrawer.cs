using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//JaJuan Webster
//Professor Cascioli
//Playing With Forces

namespace Webster_MonoGame_PlayingWithForces
{
    class ShapeDrawer
    {
        //Attributes
        SpriteBatch spriteBatch;
        public Texture2D pixel;

        //Constructor
        public ShapeDrawer(SpriteBatch sb, GraphicsDevice gd)
        {
            spriteBatch = sb;
            //make a pixel texture and fill it
            pixel = new Texture2D(gd, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });
        }

        /// <summary>
        /// Draws an arbitrary line on the screen. This assumes that spritebatch.Begin() has already been called.
        /// </summary>
        /// <param name="x0">X coord for first point</param>
        /// <param name="y0">Y coord for first point</param>
        /// <param name="x1">X coord for second point</param>
        /// <param name="y1">Y coord for second point</param>
        /// <param name="thickness">"width" of the line</param>
        /// <param name="color">color of the line</param>
        public void DrawLine(int x0, int y0, int x1, int y1, int thickness, Color color)
        {
            //Calculate the length of the line
            float length = Vector2.Distance(new Vector2(x0, y0), new Vector2(x1, y1));

            //Calculate the angle between our desired line and the x axis
            float angle = (float)Math.Atan2(y1 - y0, x1 - x0);

            //Create the rectangle we intend to draw
            Rectangle rectToDraw = new Rectangle(x0, y0, (int)length, thickness);

            //Use the Draw() overload that accepts a rotation
            spriteBatch.Draw(pixel, rectToDraw, null, color, angle, new Vector2(0.0f, 0.5f), SpriteEffects.None, 0.0f);
        }

        /// <summary>
        /// Draws an small point on the screen. Points are created by 1*1 rectangles
        /// </summary>
        /// <param name="x">x coord for the point</param>
        /// <param name="y">y coord for the point</param>
        /// <param name="color">color of the point</param>
        public void DrawPoint(int x, int y, Color color)
        {
            //Create the rectangle with the proper width and height so it comes out as a point
            Rectangle rectToDraw = new Rectangle(x, y, 1, 1);

            //Use the Draw() method
            spriteBatch.Draw(pixel, rectToDraw, color);
        }

        /// <summary>
        /// Draws a filled rectangle on the screen. uses the same code as a point, but instead the user inputs the width and height.
        /// </summary>
        /// <param name="x">x coord for the rectangle</param>
        /// <param name="y">y coord for the rectangle</param>
        /// <param name="width">width of the rectangle</param>
        /// <param name="height">height of the rectangle</param>
        /// <param name="color">color of the rectangle</param>
        public void DrawRectFilled(int x, int y, int width, int height, Color color)
        {
            //Create the rectangle
            Rectangle rectToDraw = new Rectangle(x, y, width, height);

            //Use the Draw() method
            spriteBatch.Draw(pixel, rectToDraw, color);
        }

        /// <summary>
        /// Draws the outline of a rectangle (4 lines).
        /// </summary>
        /// <param name="x">x coord for the rectangle</param>
        /// <param name="y">y coord for the rectangle</param>
        /// <param name="width">width of the rectangle</param>
        /// <param name="height">height of the rectangle</param>
        /// <param name="color">color of the rectangle</param>
        public void DrawRectOutline(int x, int y, int width, int height, Color color)
        {
            int thickness = 2;

            //Create the rectangle
            Rectangle rectToDraw = new Rectangle(x, y, width, height);

            //Draw the 4 lines utilizing the created rectangle, properly putting the thickness in the correct spots to make the outline
            //Left line            
            spriteBatch.Draw(pixel, new Rectangle(rectToDraw.Left, rectToDraw.Top, thickness, rectToDraw.Height), color);

            //Right line
            spriteBatch.Draw(pixel, new Rectangle(rectToDraw.Right, rectToDraw.Top, thickness, rectToDraw.Height), color);

            //Top line
            spriteBatch.Draw(pixel, new Rectangle(rectToDraw.Left, rectToDraw.Top, rectToDraw.Width, thickness), color);

            //Bottom line
            spriteBatch.Draw(pixel, new Rectangle(rectToDraw.Left, rectToDraw.Bottom, rectToDraw.Width, thickness), color);
        }
    }
}
