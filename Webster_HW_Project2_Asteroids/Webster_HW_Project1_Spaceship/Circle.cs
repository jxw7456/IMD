using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

//JaJuan Webster
//Professor Cascioli
//Asteroids!

namespace Webster_HW_Project2_Asteroids
{
    class Circle
    {
        //Fields
        private SpriteBatch spriteBatch;
        private Texture2D pixel;
        private float x;
        private float y;
        private float radius;

        //Get Set Properties for X, Y, and Radius
        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        //Constructor
        public Circle(SpriteBatch sb, GraphicsDevice gd)
        {
            this.spriteBatch = sb;

            // Set up the texture also
            pixel = new Texture2D(gd, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });
        }

        public void DrawLine(int x0, int y0, int x1, int y1, int thickness, Color color)
        {
            // Calculate the distance between the points
            float dist = Vector2.Distance(new Vector2(x0, y0), new Vector2(x1, y1));

            // Get the angle of the line
            float angleOfLine = (float)Math.Atan2(y1 - y0, x1 - x0);

            // Create an axis aligned rectangle of the correct size
            Rectangle rect = new Rectangle(x0, y0, (int)Math.Ceiling(dist), thickness);

            // Draw
            spriteBatch.Draw(pixel, rect, null, color, angleOfLine, new Vector2(0, 0.5f), SpriteEffects.None, 0.0f);
        }

        public void DrawCircle(int x, int y, int radius, int segments, Color color)
        {
            // Verify valid params
            if (segments <= 0) return;

            // Starting point
            float currentX = x + radius;
            float currentY = y;

            // Angle per segment
            float step = MathHelper.TwoPi / segments;
            float currentAngle = step;

            // Loop through the requested number of segments
            for (int i = 0; i < segments; i++)
            {
                // Calc new point on unit circle
                float newX = (float)Math.Cos(currentAngle);
                float newY = (float)Math.Sin(currentAngle);

                // Move to desired location
                newX = newX * radius + x;
                newY = newY * radius + y;

                // Draw from current to new
                DrawLine((int)currentX, (int)currentY, (int)newX, (int)newY, 1, color);

                // Save values
                currentX = newX;
                currentY = newY;

                // Adjust angle
                currentAngle += step;
            }
        }
    }
}
