using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//JaJuan Webster
//Professor Cascioli
//MonoGame ShapeDrawer

namespace Webster_MonoGame_ShapeDrawer
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
        /// Draws and arbitrary line on the screen. This assumes that spritebatch.Begin() has already been called.
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
    }
}
